using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Common.Network;
using Common.Utility;
using Common.Packet;
using Common.Crypt;
using Common.Database;
using Game.Service;

using Game.Network;
using Game.Packet;
using System.Threading;


namespace Game
{
    public class GameCore
    {
        
        MySqlDatabaseConnection mySqlDatabaseConnection;
        DatabaseOperations databaseOperations;
        SocketServer socketServer;
        UserManager clientManager;
        PacketHandler packetHandler;

        MapService mapService = MapService.Instance;
        PlayerService playerService = PlayerService.Instance;
        FeedbackService feedbackService = FeedbackService.Instance;

        public GameCore()
        {
            
          
            Logger.Info("[GameCore] Starting...");
            SimpleModulus.InitCryptSite(true);
            Logger.Info("[GameCore] Crypt Keys Change To Server Side");
            Xor32Modulus.InitKeys(true);
            Logger.Info("[GameCore] Crypt Keys Change To Old Keys");
            OpCodes.Init();
            Logger.Info("[GameCore] OpCodes Initialized");
            
            
            if(!MySqlDatabaseConnection.Initialize(Define.databaseHost,Define.databasePort, Define.databaseName, Define.databaseLogin, Define.databasePassword))
            {
                MessageBox.Show("No Connection MySql. Exit Process");
                Application.Exit();
            }
            
           
            socketServer = SocketServer.Instance;
            socketServer.Initialize(Define.port, Define.ipAddress);
            clientManager = UserManager.Instance;
            packetHandler = PacketHandler.Instance;
            mapService.Init();
            Logger.Info("[GameCore] Server Succesfully Initialized, Waiting For Listen");

        }
        public void StartGame()
        {
            
            socketServer.Listen();
            Thread thread = new Thread(new ThreadStart(MainLoop));
            thread.Start();
           // MainLoop();
        }
        public void StopGame()
        {

        }
        private void MainLoop()
        {

            while (true)
            {
                
            };
        }
    }

}
