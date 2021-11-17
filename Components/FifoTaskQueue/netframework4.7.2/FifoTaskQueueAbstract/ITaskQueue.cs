﻿/**
 * LICENSE
 *
 * This source file is subject to the new BSD license that is bundled
 * with this package in the file LICENSE.txt.
 *
 * @copyright   Copyright (c) 2021. Fernando Macias Ruano.
 * @E-Mail      fmaciasruano@gmail.com > .
 * @license    https://github.com/fmacias/Scheduler/blob/master/Licence.txt
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fmacias.Components.FifoTaskQueueAbstract
{
    public interface ITaskQueue: IDisposable
    {
        TaskScheduler TaskSheduler { get; }
        ITaskQueue Run(ITaskObserver<Task> observer, params object[] parameters);
        ITaskQueue Run(ITaskObserver<Task> observer);
        void CancelExecution();
        CancellationToken CancellationToken { get; }
        List<Task> Tasks { get; }
        void ClearUpTasks();
        Task<bool> Complete();
        Task<bool> CancelAfter(int taskCancelationTime);
        ITaskObserver<Task> Define(Action action);
        ITaskObserver<Task> Define(Action<object> actionParams);
    }
}