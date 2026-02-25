using System;

namespace Task.GameMechanics
{
    internal abstract class CasinoGameBase
    {
        public static event Action OnWin;
        public static event Action OnLose;
        public static event Action OnDraw;
        protected readonly Random _random;
        protected CasinoGameBase()
        {
            _random = new Random();
        }
        public abstract void PlayGame();
        protected void OnWinInvoke() => OnWin();
        protected void OnLooseInvoke() => OnLose();
        protected void OnDrawInvoke() => OnDraw();
        protected abstract void FactoryMethod();
        //к сожалению, я не поняла, что в контексте данной задачи должен производить и как должен работать FactoryMethod.
        //понимаю, что этот вариант неверный и он точно не void, но оставляю так.
    }
}
