﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Observer
{
    public class Subject : ISubject
    {
        public int State { get; set; } = 0;

        private List<IObserver> _observers = new List<IObserver>();

        public Subject()
        {

        }

        public void Subscribe(IObserver observer)
        {
            Console.WriteLine("Subject: Subscribed an observer.");
            this._observers?.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Unsubscribed an observer.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            this.Notify();
        }
    }
}