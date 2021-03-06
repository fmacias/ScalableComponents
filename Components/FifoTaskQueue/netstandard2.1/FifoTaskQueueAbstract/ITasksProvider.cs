/**
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
using System.Threading.Tasks;

namespace fmacias.Components.FifoTaskQueueAbstract
{
    public interface ITasksProvider: IObservable<Task>
    {
        Task<List<bool>> CompleteQueueObservation();
        List<Task> GetProcessingTasks();
        IDisposable Subscribe(IObserver<Task> observer);
        Task<bool> UnsubscribeObservers();
    }
}