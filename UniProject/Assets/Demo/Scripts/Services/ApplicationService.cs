﻿using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Stateless;
using UniProject.Abstractions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UniProject.Demo
{
    public class ApplicationService : AService, IApplicationService
    {

        #region data

        private StateMachine<State, Trigger> StateMachine { get; }
            = new StateMachine<State, Trigger>(State.Start, FiringMode.Queued);

        #endregion

        public void StartGame()=> StateMachine.FireAsync(Trigger.StartGame);

        public void OpenMenu()=> StateMachine.FireAsync(Trigger.BackToMenu);


        public override void Initialize()
        {
            base.Initialize();

            ConfigureStateMachine();
            Start();

            UnityEngine.Application.targetFrameRate = 60;
            UnityEngine.Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
        
        private void Start() => StateMachine.FireAsync(Trigger.StartLoading);

        private void ConfigureStateMachine()
        {
            StateMachine.Configure(State.Start)
                .Permit(Trigger.StartLoading, State.Menu)
                .OnExit( async () =>
                {
                    await LoadSceneAsync(Scene.Overlay, LoadSceneMode.Additive, false);
                    await UnloadSceneAsync(Scene.Start);
                });

            StateMachine.Configure(State.Menu)
                .Permit(Trigger.StartGame, State.Game)
                .OnEntry(async () =>
                {
                    //await LoadSceneAsync(Scene.Overlay, LoadSceneMode.Additive, false);
                    await LoadSceneAsync(Scene.Menu, LoadSceneMode.Additive);
                })
                .OnExit(async () =>
                {
                    await UnloadSceneAsync(Scene.Menu);
                });

            StateMachine.Configure(State.Game)
                .Permit(Trigger.BackToMenu, State.Menu)
                .OnEntry(async () =>
                {
                    await LoadSceneAsync(Scene.Game, LoadSceneMode.Additive);
                })
                .OnExit(async () =>
                {
                    await UnloadSceneAsync(Scene.Game);
                    GC.Collect();
                    Resources.UnloadUnusedAssets();
                });
        }

        private async Task LoadSceneAsync(Scene scene,
            LoadSceneMode loadSceneMode = LoadSceneMode.Single, bool makeActive = true)
        {
            var sceneName = scene.ToString();
            var asyncOp = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);

            await asyncOp;
            if (makeActive)
            {
                var sceneInstance = SceneManager.GetSceneByName(sceneName);
                SceneManager.SetActiveScene(sceneInstance);
            }
        }

        private async Task UnloadSceneAsync(Scene scene)
        {
            var asyncOp = SceneManager.UnloadSceneAsync(scene.ToString());
            await asyncOp;
        }

        private enum State
        {
            Start,
            Menu,
            Game
        }

        private enum Trigger
        {
            StartLoading,
            BackToMenu,
            StartGame
        }

        private enum Scene
        {
            Start,
            Overlay,
            Game,
            Menu
        }
    }
}
