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
using System.Threading.Tasks;
using FifoTaskQueue.Fmaciasruano.Components;
using Moq;
using NLog;
using NUnit.Framework;
using FifoTaskQueueAbstractComponents = FifoTaskQueueAbstract.Fmaciasruano.Components;
using FifoTaskQueueComponents = FifoTaskQueue.Fmaciasruano.Components;
using FifoTaskQueueAbstract.Fmaciasruano.Components;

namespace FifoTaskQueueNC5_0.Test.Fmaciasruano.Components
{
    [TestFixture()]
    public class TasksProviderTests
    {
        private IActionObserver<Action> taskObserver;

        [SetUp]
        public void Initialize()
        {
            taskObserver = TaskObserver<Action>.Create(GetLogger());
        }
        private ILogger GetLogger()
        {
            Mock<ILogger> logger = new Mock<ILogger>();
            logger.Setup(p => p.Info(It.IsAny<string>()));
            logger.Setup(p => p.Debug(It.IsAny<string>()));
            logger.Setup(p => p.Warn(It.IsAny<string>()));
            logger.Setup(p => p.Error(It.IsAny<string>()));
            return logger.Object;
        }
        [Test()]
        public void TasksProviderTest()
        {
            Assert.IsInstanceOf<IObservable<Task>>(TasksProvider.Create(GetLogger()));
        }

        [Test()]
        public void SubscribeTest()
        {
            Task<IJobRunner> task = Task.Run<IJobRunner>(() => { return JobAction<IJobRunner>.Create(); });
            TasksProvider provider = TasksProvider.Create(GetLogger()); 
            taskObserver.OnNext(task);
            IDisposable unsubscriber = provider.Subscribe(taskObserver);
            Assert.IsInstanceOf<IDisposable>(provider.Subscribe(taskObserver));
        }

        [Test()]
        public void SubscriptionsTest()
        {
            Task task = Task.Run(() => { });
            TasksProvider provider = TasksProvider.Create(GetLogger());
            IDisposable unsubscriber = provider.Subscribe(taskObserver);
            Assert.IsInstanceOf<FifoTaskQueueAbstractComponents.IObserver[]>(provider.Subscriptions);
            Assert.AreEqual(1, provider.Subscriptions.Length);
            unsubscriber.Dispose();
            Assert.AreEqual(0, provider.Subscriptions.Length);
        }
    }
}