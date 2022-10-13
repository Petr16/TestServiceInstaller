using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace FileWatcherService
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        //https://metanit.com/sharp/tutorial/21.2.php
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;

        public Installer1()
        {
            InitializeComponent();
            serviceInstaller = new ServiceInstaller();//предназначен для настройки значений для каждой из запускаемых служб.
                                                      //То есть если у нас запускается три службы, то для каждой службы создается свой объект ServiceInstaller.
                                                      //Но в нашем случае мы определили только одну запускаемую службу, поэтому объекты обоих классов у нас будут только в одном экземпляре.
            processInstaller = new ServiceProcessInstaller();//управляет настройкой значений для всех запускаемых служб внутри одного процесса
                                                             //(метод Main класса Program может одновременно запускать несколько служб).

            processInstaller.Account = ServiceAccount.LocalSystem;//учетная запись предоставляет широкие привилегии на локальном компьютере и соответствует компьютеру в сети
            serviceInstaller.StartType = ServiceStartMode.Manual;//Manual(вручную),Automatic (автоматический запуск),Disabled (служба по умолчанию отключена)
            serviceInstaller.ServiceName = "Service1";//имя службы, должно совпадать со значением свойства ServiceName у класса службы
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
