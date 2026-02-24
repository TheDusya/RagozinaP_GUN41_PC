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
            _random = new Random();
        }
        public abstract void PlayGame();
        protected void OnWinInvoke() => OnWin?.Invoke();
        protected void OnLooseInvoke() => OnLose?.Invoke();
        protected void OnDrawInvoke() => OnDraw?.Invoke();
        protected abstract void FactoryMethod();
        //к сожалению, я не поняла, что в контексте данной задачи должен производить и как должен работать FactoryMethod.
        //понимаю, что этот вариант неверный и он точно не void, но оставляю так.
    }
}
