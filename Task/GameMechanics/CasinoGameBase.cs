using System;

namespace Task.GameMechanics
{
    internal abstract class CasinoGameBase
    {
        private event Action OnWin;
        private event Action OnLose;
        private event Action OnDraw;
        protected readonly Random _random;
        public CasinoGameBase() 
        {
            FactoryMethod();
            _random = new Random();
        }
        public abstract void PlayGame();
        protected void OnWinInvoke() => OnWin?.Invoke();
        protected void OnLooseInvoke() => OnLose?.Invoke();
        protected void OnDrawInvoke() => OnDraw?.Invoke();
        protected abstract void FactoryMethod();
    }
}
