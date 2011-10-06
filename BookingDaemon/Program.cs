﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Booking.Persistence.FileSystem;
using System.IO;
using Ploeh.Samples.Booking.PersistenceModel;
using System.Threading;
using Ploeh.Samples.Booking.JsonAntiCorruption;
using Ploeh.Samples.Booking.DomainModel;

namespace Ploeh.Samples.Booking.Daemon
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new QueueConsumer(
                new FileQueue(
                    new DirectoryInfo(@"..\..\..\BookingWebUI\Queue"),
                    "txt"),
                new JsonStreamObserver(
                    new[]
                    {
                        new RequestReservationCommand.Quickening()
                    }));
            while (true)
            {
                q.ConsumeAll();
                Thread.Sleep(500);
            }
        }
    }
}