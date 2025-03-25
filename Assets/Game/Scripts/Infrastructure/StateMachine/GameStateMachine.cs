using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services.DIContainer;
using CodeHub.StateMachine.States;

namespace CodeHub.StateMachine
{
    public class GameStateMachine : AbstractStateMachine, IService
    {
        public GameStateMachine(BootstrapState bootstrapState, CharacterSelectorState characterSelectorState,
            GameState gameState)
        {
            States = new Dictionary<Type, IExitableState>();

            States[typeof(BootstrapState)] = bootstrapState;

            States[typeof(CharacterSelectorState)] = characterSelectorState;
            States[typeof(GameState)] = gameState;
        }
    }
}