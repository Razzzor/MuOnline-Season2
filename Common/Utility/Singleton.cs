using System;


namespace Common.Utility
{

    [Serializable]
    public abstract class Singleton<T>
        where T : new()
    {



        public static T Instance
        {
            get
            {
                return SingletonHolder.instance;
            }

            set
            {
                SingletonHolder.instance = value;
            }
        }


        private sealed class SingletonHolder
        {

            internal static T instance = new T();


            static SingletonHolder()
            {
            }


        }
    }
}
    

