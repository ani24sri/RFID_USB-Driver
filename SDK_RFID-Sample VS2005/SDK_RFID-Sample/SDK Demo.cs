using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using SDK_SC_RFID_Devices;
using DataClass;

namespace SDK_RFID_Sample
{
    public partial class SDK_Demo : Form
    {

        // define max user for array size - No limitation of size.
        private const int nbMaxUser = 100;
        private int indexUser = 0;
        UserClassTemplate[] userArray = new UserClassTemplate[nbMaxUser];

        rfidPluggedInfo[] arrayOfPluggedDevice = null;
        string[] fpDevArray = null;
        int selectedDevice = 0;
        int selectedFP = 0;

        //General device object
        private RFID_Device device = null;

        public SDK_Demo()
        {
            InitializeComponent();
        }

        //Function to discover device
        //This function will search all the RFID device and fingerprint plugged on the PC
        //Take care to choose the good value depending of the serial numbers printed on the device.
        private void FindDevice()
        {
            arrayOfPluggedDevice = null;
            RFID_Device tmp = new RFID_Device();
            arrayOfPluggedDevice = tmp.getRFIDpluggedDevice(false);
            fpDevArray = tmp.getFingerprintPluggedGUID();
            tmp.ReleaseDevice();
            comboBoxDevice.Items.Clear();
            if (arrayOfPluggedDevice != null)
            {
                foreach (rfidPluggedInfo dev in arrayOfPluggedDevice)
                {
                    comboBoxDevice.Items.Add(dev.SerialRFID);
                }                
            }          

            comboBoxFP.Items.Clear();
            if (fpDevArray != null)
            {
                foreach (string fpDev in fpDevArray)
                {
                    comboBoxFP.Items.Add(fpDev);
                }
            }

            if ((comboBoxDevice.Items.Count > 0) && (comboBoxFP.Items.Count > 0))
            {
                comboBoxDevice.SelectedIndex = 0;
                comboBoxFP.SelectedIndex = 0;
                buttonCreate.Enabled = true;
            }
            else
            {
                buttonCreate.Enabled = false;
                Invoke((MethodInvoker)delegate { toolStripStatusLabelInfo.Text = "Info : No RFID and/or Fingerprint detected - try Refresh"; });
            }           

        }


        // Button create device
        private void button1_Click(object sender, EventArgs e)
        {
            // release previous object if not connected
            if (device != null)
            {
                if (device.ConnectionStatus != ConnectionStatus.CS_Connected)   
                    device.ReleaseDevice();
            }
            //Create a new object 
            device = new RFID_Device();
            toolStripStatusLabelInfo.Text = "Info RFID : In Connection ";
            buttonCreate.Enabled = false;
            //subscribe the event 
            device.NotifyRFIDEvent += new NotifyHandlerRFIDDelegate(rfidDev_NotifyRFIDEvent);
            device.NotifyFPEvent += new NotifyHandlerFPDelegate(rfidDev_NotifyFPEvent);
            //Create a DSB device
            //As the function search on all the serial port of the PC, this connection can
            //take some time and is under a thread pool to avoid freeze of the GUI
            ThreadPool.QueueUserWorkItem(
                delegate
                {     
               
                    switch (arrayOfPluggedDevice[selectedDevice].deviceType)
                    {
                        case DeviceType.DT_DSB:
                        case DeviceType.DT_SBX:
                        case DeviceType.DT_JSC:
                       
                            //  Use create with portcom parameter for speed connection (doesn't search again the reader at is is previouly done;
                            //  recover guid FP in devFParray
                            //  bLoadTemplateFromDB mandatory to false
                            device.Create_1FP_Device(arrayOfPluggedDevice[selectedDevice].SerialRFID, arrayOfPluggedDevice[selectedDevice].portCom,fpDevArray[selectedFP],false);
                                                       
                            break;

                        default:
                            MessageBox.Show("Device not created - Only device with fingerprint allowed \r\n\t\tDevice Detected : " + arrayOfPluggedDevice[selectedDevice].deviceType.ToString());
                                break;
                    }
                    
                });          
            
        }     
        // button dispose
        private void buttonDispose_Click(object sender, EventArgs e)
        {
            if (device == null) return;
            if (device.ConnectionStatus == ConnectionStatus.CS_Connected)  
                device.ReleaseDevice();
            buttonCreate.Enabled = true;
        }
        // Function to get rfid event
        private void rfidDev_NotifyRFIDEvent(object sender, SDK_SC_RfidReader.rfidReaderArgs args)
        {
            switch (args.RN_Value)
            {
                // Event when failed to connect          
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_FailedToConnect:
                     Invoke((MethodInvoker)delegate {toolStripStatusLabelInfo.Text = "Info RFID : Failed to Connect";});
                     Invoke((MethodInvoker)delegate { buttonCreate.Enabled = true; });                    
                     Invoke((MethodInvoker)delegate { buttonDispose.Enabled = false; });
                     Invoke((MethodInvoker)delegate { groupBoxCtrl.Enabled = false; });
                     Invoke((MethodInvoker)delegate { groupBoxFP.Enabled = false; });
                break;
                // Event when release the object
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_Disconnected:
                     Invoke((MethodInvoker)delegate {toolStripStatusLabelInfo.Text = "Info RFID : Device Disconnected";});
                     Invoke((MethodInvoker)delegate { buttonCreate.Enabled = true; });
                     Invoke((MethodInvoker)delegate { buttonDispose.Enabled = false; });
                     Invoke((MethodInvoker)delegate { groupBoxCtrl.Enabled = false; });
                     Invoke((MethodInvoker)delegate { groupBoxFP.Enabled = false; });
                break;

                //Event when device is connected
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_Connected:
                     Invoke((MethodInvoker)delegate {toolStripStatusLabelInfo.Text = "Info RFID : Device Connected";});
                     Invoke((MethodInvoker)delegate { buttonCreate.Enabled = false; });
                     Invoke((MethodInvoker)delegate { buttonDispose.Enabled = true; });
                     Invoke((MethodInvoker)delegate { groupBoxCtrl.Enabled = true; });
                     Invoke((MethodInvoker)delegate { groupBoxFP.Enabled = true; });
                break;

                // Event when scan started
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_ScanStarted:

                      Invoke((MethodInvoker)delegate { buttonScan.Enabled = false; });
                      Invoke((MethodInvoker)delegate { buttonStop.Enabled = true; });
                      Invoke((MethodInvoker)delegate { toolStripStatusLabelInfo.Text = "Info RFID : Scan Started"; });
                      listBoxTag.Invoke((MethodInvoker)delegate { listBoxTag.Items.Clear(); });
                      labelInventoryTagCount.Invoke((MethodInvoker)delegate { labelInventoryTagCount.Text = "Tag(s): 0"; });
                break;

                //event when fail to start scan
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_ReaderFailToStartScan:
                    Invoke((MethodInvoker)delegate { buttonScan.Enabled = true; });
                    Invoke((MethodInvoker)delegate { buttonStop.Enabled = false; });
                    Invoke((MethodInvoker)delegate { toolStripStatusLabelInfo.Text = "Info RFID: Failed to start scan"; });
                break;

                //event when a new tag is identify
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_TagAdded:
                    listBoxTag.Invoke((MethodInvoker)delegate { listBoxTag.Items.Add(args.Message); });
                    labelInventoryTagCount.Invoke((MethodInvoker)delegate { labelInventoryTagCount.Text = "Tag(s) : " + listBoxTag.Items.Count.ToString("000"); });
                break;

                // Event when scan completed
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_ScanCompleted:
                    Invoke((MethodInvoker)delegate { buttonScan.Enabled = true; });
                    Invoke((MethodInvoker)delegate { buttonStop.Enabled = false; });
                    Invoke((MethodInvoker)delegate { toolStripStatusLabelInfo.Text = "Info RFID: Scan Completed"; });
                break;

                 //error when error during scan
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_ReaderScanTimeout:
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_ErrorDuringScan:
                    Invoke((MethodInvoker)delegate { buttonScan.Enabled = true; });
                    Invoke((MethodInvoker)delegate { buttonStop.Enabled = false; });
                    Invoke((MethodInvoker)delegate { toolStripStatusLabelInfo.Text = "Info RFID: Scan has error"; });
                break;
                // Scan cancel by user
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_ScanCancelByHost:
                    Invoke((MethodInvoker)delegate { buttonScan.Enabled = true; });
                    Invoke((MethodInvoker)delegate { buttonStop.Enabled = false; });
                    Invoke((MethodInvoker)delegate { toolStripStatusLabelInfo.Text = "Info RFID : Scan cancel by host"; });
                break;
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_Door_Opened:
                        Invoke((MethodInvoker)delegate { toolStripStatusLabelInfo.Text = "Info RFID : Door Open"; });
                break;
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_Door_Closed:
                Invoke((MethodInvoker)delegate { toolStripStatusLabelInfo.Text = "Info RFID : Door Close"; });
                break;

            }
            Application.DoEvents();
        }
        //function to get FP event
        private void rfidDev_NotifyFPEvent(object sender, SDK_SC_Fingerprint.FingerArgs args)
        {
           switch(args.RN_Value)
           {
               case SDK_SC_Fingerprint.FingerArgs.FingerNotify.RN_FingerprintConnect:

                    Invoke((MethodInvoker)delegate {toolStripStatusLabelFP.Text = "        - Info FP : Connected";});
                    break;

               case SDK_SC_Fingerprint.FingerArgs.FingerNotify.RN_FingerprintDisconnect:
                   Invoke((MethodInvoker)delegate {toolStripStatusLabelFP.Text = "        - Info FP : Disonnected";});
                    break;
               case SDK_SC_Fingerprint.FingerArgs.FingerNotify.RN_FingerTouch:
                   Invoke((MethodInvoker)delegate {toolStripStatusLabelFP.Text = "        - Info FP : Sensor touched";});
                    break;

               case SDK_SC_Fingerprint.FingerArgs.FingerNotify.RN_FingerGone:
                    Invoke((MethodInvoker)delegate { toolStripStatusLabelFP.Text = "        - Info FP : Finger Remove"; });
                    break;
               case SDK_SC_Fingerprint.FingerArgs.FingerNotify.RN_FingerUserUnknown:
                    Invoke((MethodInvoker)delegate { toolStripStatusLabelFP.Text = "        - Info FP : Unknown user"; });
                    break;
               case SDK_SC_Fingerprint.FingerArgs.FingerNotify.RN_AuthentificationCompleted:

                    string[] strUser = args.Message.Split(';');
                    string FirstName = strUser[0];
                    string LastName = strUser[1];
                    SDK_SC_Fingerprint.FingerIndexValue fingerUsed = (SDK_SC_Fingerprint.FingerIndexValue)int.Parse(strUser[2]);
                    string userInfo = FirstName + " " + LastName + "(" + fingerUsed.ToString() + ")";
                    Invoke((MethodInvoker)delegate { toolStripStatusLabelFP.Text = "        - Info FP : User - " + userInfo; });
                    System.Threading.Thread.Sleep(1000);
                    break;
           }                  
        }

        // button Scan
        private void buttonScan_Click(object sender, EventArgs e)
        {
            if (device == null) return;
            if ((device.ConnectionStatus == ConnectionStatus.CS_Connected) &&
                (device.DeviceStatus == DeviceStatus.DS_Ready))
            {             
                //Request a scan
                //Scan status will be notified by event
                device.ScanDevice();
            }
            else
                MessageBox.Show("Device not ready or not connected");
        }

        //Button Stop
        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (device == null) return;
            if ((device.ConnectionStatus == ConnectionStatus.CS_Connected) &&
                  (device.DeviceStatus == DeviceStatus.DS_InScan))
                device.StopScan();
       
        }

        private void SDK_Demo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (device == null) return;
            if (device.ConnectionStatus == ConnectionStatus.CS_Connected)
                device.ReleaseDevice();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate { toolStripStatusLabelInfo.Text = "Info RFID : Search connected device"; });
            FindDevice();
        }

        private void SDK_Demo_Load(object sender, EventArgs e)
        {          
            FindDevice();           
        }

        private void comboBoxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDevice = comboBoxDevice.SelectedIndex;
        }
        private void comboBoxFP_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFP = comboBoxFP.SelectedIndex;
        }

        private void buttonEnrol_Click(object sender, EventArgs e)
        {

            UserClassTemplate uct = new UserClassTemplate();

            uct.firstName = textBoxFirstName.Text;
            uct.lastName = textBoxLastName.Text;


            // serial FP to null for all the FP device
            // template to null - it's a new one
            uct.template = device.EnrollUser(null, uct.firstName, uct.lastName, null);

            // To do 
            // Save fingerprint template


            userArray[indexUser++] = uct;
            listBoxUser.Items.Add(uct.firstName + " " + uct.lastName);

            textBoxFirstName.Text = null;
            textBoxLastName.Text = null;

            loadTemplate();

        }

        private void listBoxUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int selectedIndex = listBoxUser.SelectedIndex;
            if (selectedIndex == -1) return;

            userArray[selectedIndex].template = device.EnrollUser(null, userArray[selectedIndex].firstName, userArray[selectedIndex].lastName, userArray[selectedIndex].template);

            // To do 
            // Save fingerprint template

            loadTemplate();
        }

        private void loadTemplate()
        {

            string[] templateToLoad = new string[indexUser + 1];

            for (int loop = 0; loop < indexUser; loop++)
            {
                templateToLoad[loop] = userArray[loop].template;
            }
            device.LoadFPTemplate(templateToLoad, device.get_FP_Master);
        }                  
    }


    public class UserClassTemplate
    {
        public string firstName;
        public string lastName;
        public string template; 
    }
}
