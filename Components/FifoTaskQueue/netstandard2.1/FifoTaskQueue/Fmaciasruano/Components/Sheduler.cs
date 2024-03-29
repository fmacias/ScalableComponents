﻿/**
 * LICENSE
 *
 * This source file is subject to the new BSD license that is bundled
 * with this package in the file LICENSE.txt.
 *
 * @copyright   Copyright (c) 2021. Fernando Macias Ruano.
 * @E-Mail      fmaciasruano@gmail.com 
 * @license    https://github.com/fmacias/Scheduler/blob/master/Licence.txt
 */

using System.Threading;
using System.Threading.Tasks;

namespace FifoTaskQueue.Fmaciasruano.Components
{
    internal class Sheduler
    {

        /// <summary>
        /// Creates the Sheduler from <see cref="SynchronizationContext"/> associated
        /// with the worker from with it was started
        /// </summary>
        /// <returns></returns>
        public static TaskScheduler FromCurrentWorker()
        {
            return TaskScheduler.Current;
        }

        /// <summary>
        /// Creates the Sheduler from <see cref="SynchronizationContext"/> associated
        /// with the main thread of the application.
        /// Use this to use to be able to interact with  the GUI(Forms and Windows Presentation Foundation (WPF)) 
        /// Objects.
        /// GUI objects are accesible only from the thread that creates and manages the UI (the Main or UI thread)
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception?view=net-5.0"/>
        /// </summary>
        /// <returns></returns>
        public static TaskScheduler FromGuiWorker()
        {
            return TaskScheduler.FromCurrentSynchronizationContext();
        }
    }
}
