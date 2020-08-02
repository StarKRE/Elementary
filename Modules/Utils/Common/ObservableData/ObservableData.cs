using System;

namespace ElementaryFramework.Util
{
    public sealed class ObservableData<T> : IDisposable
    {
        #region Event

        public AutoEvent<object, ObservableData<T>, T> OnValueChangedEvent { get; }

        #endregion

        public T value { get; private set; }

        public ObservableData()
        {
            this.OnValueChangedEvent = new AutoEvent<object, ObservableData<T>, T>();
        }

        public ObservableData(T value) : this()
        {
            this.value = value;
        }

        public void SetValue(object sender, T value)
        {
            this.value = value;
            this.OnValueChangedEvent?.Invoke(sender, this, value);
        }

        public void Dispose()
        {
            this.OnValueChangedEvent?.Dispose();
        }
    }
}