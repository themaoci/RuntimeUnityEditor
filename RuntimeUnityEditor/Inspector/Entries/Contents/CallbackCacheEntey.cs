﻿using System;

namespace RuntimeUnityEditor.Inspector.Entries
{
    public class CallbackCacheEntey<T> : CacheEntryBase
    {
        private readonly string _message;
        private readonly Func<T> _callback;

        public CallbackCacheEntey(string name, string message, Func<T> callback) : base(name)
        {
            _message = message;
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        }

        public override object GetValueToCache()
        {
            return _message;
        }

        public override bool CanEnterValue()
        {
            return true;
        }

        public override object EnterValue()
        {
            return _callback();
        }

        protected override bool OnSetValue(object newValue)
        {
            return false;
        }

        public override Type Type()
        {
            return typeof(T);
        }

        public override bool CanSetValue()
        {
            return false;
        }
    }
}