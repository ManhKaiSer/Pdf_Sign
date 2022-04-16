//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.IO;
//using System.Web;
//using System.Net;
//using System.Collections;
//using System.Windows.Forms;

//using iTextSharp.text.pdf;
//using iTextSharp.text;

////using Org.BouncyCastle.Crypto;
//using Org.BouncyCastle.X509.Store;
//using Org.BouncyCastle.X509;
////using Org.BouncyCastle.Pkcs;
//using Org.BouncyCastle.Tsp;
//using Org.BouncyCastle.Math;
////using Org.BouncyCastle.Cms;
////using Org.BouncyCastle.Utilities;
//using Org.BouncyCastle.Asn1;

//namespace PDFSigner
//{
//    class PDFSign
//    {

//        #region Constants and Variables


//        //nu se poate salva sesiunea
//        //detalii: http://www.google.com/search?num=100&hl=ro&q=%22This+property+cannot+be+set+after+writing+has+started%22&meta=

//        private const string ID_TIME_STAMP_TOKEN = "1.2.840.113549.1.9.16.2.14"; // RFC 3161 id-aa-timeStampToken 

//        //private string inputFile = null;
//        //private string outputFile = null;

//        //GroupBox Position
//        private static bool basicSignature = true;
//        private static int basicSignaturePosition = 0;
//        //private static int basicSignaturePage = 0;

//        private static iTextSharp.text.Rectangle signatureRectangle = new iTextSharp.text.Rectangle(0, 0, 0, 0);

//        //public int topLeft = 0;
//        //public int topRight = 0;
//        //public int bottomLeft = 0;
//        //public int bottomRight = 0;

//        private static bool showSignature = false;
//        private static int signaturePage = 1;

//        //GroupBox Localization
//        private static string signedBy = StringEN.signDigitallySignedBy;
//        private static string signatureDate = StringEN.signDateTime;
//        private static string dateFormat = StringEN.signDateFormat;

//        private static string reasonText = null;
//        private static string locationText = null;

//        private static string signingReason = null;
//        private static string signingLocation = null;

//        //GroupBox Signing
//        private static System.Security.Cryptography.X509Certificates.X509Certificate2 signingCertificate = null;
//        private static bool doNotSignIsSigned = false;

//        //GroupBox Timestamping
//        private static bool timestampDocument = false;
//        private static string timeStampingServer = null;
//        private static string TSAPolicyOID = "1.3.6.1.4.1.601.10.3.1";
//        //private static bool TSARequiresLogOn = false;
//        private static string UserName = null;
//        private static string Password = null;
//        private static bool TSARequiresCertificate = false;
//        private static System.Security.Cryptography.X509Certificates.X509Certificate2 TSACertificateLogOn = null;

//        #endregion


//        #region Setters

//        public static object SignaturePosition
//        {
//            set
//            {

//                if (value is System.Drawing.Rectangle)
//                {
//                    System.Drawing.Rectangle rect = (System.Drawing.Rectangle)value;
//                    signatureRectangle = new iTextSharp.text.Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
//                    basicSignature = false;
//                    showSignature = true;
//                }
//                else
//                {
//                    basicSignaturePosition = (int)value;
//                    basicSignature = true;
//                    showSignature = true;
//                }
//            }
//        }

//        public static int SignaturePage
//        {
//            set
//            {
//                if (value > 0)
//                    signaturePage = value;
//                else
//                    signaturePage = 1;
//            }
//        }

//        public static string SignedBy
//        {
//            set
//            {
//                signedBy = value;
//            }
//        }

//        public static string SignatureDate
//        {
//            set
//            {
//                signatureDate = value;
//            }
//        }

//        public static string DateFormat
//        {
//            set
//            {
//                dateFormat = value;
//            }
//        }

//        public static string ReasonText
//        {
//            set
//            {
//                reasonText = value;
//            }
//        }

//        public static string LocationText
//        {
//            set
//            {
//                locationText = value;
//            }
//        }

//        public static string SigningReason
//        {
//            set
//            {
//                signingReason = value;
//            }
//        }

//        public static string SigningLocation
//        {
//            set
//            {
//                signingLocation = value;
//            }
//        }

//        public static System.Security.Cryptography.X509Certificates.X509Certificate2 SigningCertificate
//        {
//            set
//            {
//                if (value != null)
//                    signingCertificate = value;
//            }
//        }

//        public static bool DoNotSignSignedDocuments
//        {
//            set
//            {
//                doNotSignIsSigned = value;
//            }
//        }

//        public static string TSAServerURL
//        {
//            set
//            {
//                if (value != null)
//                {
//                    timeStampingServer = value;
//                    timestampDocument = true;
//                }
//                else
//                {
//                    timeStampingServer = value;
//                    timestampDocument = false;
//                }
//            }
//        }

//        public static string TSAPolicy
//        {
//            set
//            {
//                TSAPolicyOID = value;
//            }
//        }

//        public static string TSAUserName
//        {
//            set
//            {
//                UserName = value;
//                //TSARequiresLogOn = true;

//            }
//        }

//        public static string TSAPassword
//        {
//            set
//            {
//                Password = value;
//            }
//        }

//        public static System.Security.Cryptography.X509Certificates.X509Certificate2 TSACertificate
//        {
//            set
//            {
//                if (value != null)
//                {
//                    TSACertificateLogOn = value;
//                    TSARequiresCertificate = true;
//                }
//            }
//        }

//        #endregion


//        //public PDFSign(string _inputFile, string _outputFile)
//        //{
//        //   Sign(_inputFile, _outputFile);
//        //}

//        public static void ResetStructure()
//        {
//            basicSignature = true;
//            basicSignaturePosition = 0;

//            signatureRectangle = new iTextSharp.text.Rectangle(0, 0, 0, 0);

//            showSignature = false;
//            signaturePage = 1;

//            //GroupBox Localization
//            signedBy = StringEN.signDigitallySignedBy;
//            signatureDate = StringEN.signDateTime;
//            dateFormat = StringEN.signDateFormat;

//            reasonText = null;
//            locationText = null;

//            signingReason = null;
//            signingLocation = null;

//            //GroupBox Signing
//            signingCertificate = null;
//            doNotSignIsSigned = false;

//            //GroupBox Timestamping
//            timestampDocument = false;
//            timeStampingServer = null;
//            TSAPolicyOID = "1.3.6.1.4.1.601.10.3.1";
//            UserName = null;
//            Password = null;
//            TSARequiresCertificate = false;
//            TSACertificateLogOn = null;

//        }

//        private static byte[] ComputeHash(byte[] msg)
//        {
//            try
//            {
//                System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
//                return sha.ComputeHash(msg);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        private static byte[] SignMsg(byte[] msg, System.Security.Cryptography.X509Certificates.X509Certificate2 signerCert)
//        {
//            try
//            {
//                //  Place message in a ContentInfo object.
//                //  This is required to build a SignedCms object.
//                System.Security.Cryptography.Pkcs.ContentInfo contentInfo = new System.Security.Cryptography.Pkcs.ContentInfo(msg);

//                //  Instantiate SignedCms object with the ContentInfo above.
//                //  Has default SubjectIdentifierType IssuerAndSerialNumber.
//                System.Security.Cryptography.Pkcs.SignedCms signedCms = new System.Security.Cryptography.Pkcs.SignedCms(contentInfo, false);

//                //  Formulate a CmsSigner object for the signer.
//                System.Security.Cryptography.Pkcs.CmsSigner cmsSigner = new System.Security.Cryptography.Pkcs.CmsSigner(signerCert);

//                // Include the following line if the top certificate in the
//                // smartcard is not in the trusted list.
//                cmsSigner.IncludeOption = System.Security.Cryptography.X509Certificates.X509IncludeOption.EndCertOnly;

//                //  Sign the CMS/PKCS #7 message. The second argument is
//                //  needed to ask for the pin.
//                signedCms.ComputeSignature(cmsSigner, false);

//                //  Encode the CMS/PKCS #7 message.
//                return signedCms.Encode();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        private static byte[] SignMsgTSA(byte[] msg, System.Security.Cryptography.X509Certificates.X509Certificate2 signerCert, string TSAServer, System.Security.Cryptography.X509Certificates.X509Certificate2 tsaCert, string username, string password)
//        {
//            //const string TsaServerUrl = "http://dse200.ncipher.com/TSS/HttpTspServer";
//            //const string TsaServerUrl = "http://www.edelweb.fr/cgi-bin/service-tsp";
//            //const string TsaServerUrl = "http://timestamp.verisign.com/scripts/timstamp.dll";
//            //asta e offline
//            //string TsaServerUrl = "http://ns.szikszi.hu:8080/tsa";
//            //string TsaServerUrl = "http://www.edelweb.fr/cgi-bin/service-tsp";

//            try
//            {
//                //efectual semnatura fara TSA
//                System.Security.Cryptography.Pkcs.ContentInfo contentInfo = new System.Security.Cryptography.Pkcs.ContentInfo(msg);
//                System.Security.Cryptography.Pkcs.SignedCms signedCms = new System.Security.Cryptography.Pkcs.SignedCms(contentInfo, false);
//                System.Security.Cryptography.Pkcs.CmsSigner cmsSigner = new System.Security.Cryptography.Pkcs.CmsSigner(signerCert);
//                cmsSigner.IncludeOption = System.Security.Cryptography.X509Certificates.X509IncludeOption.EndCertOnly;
//                signedCms.ComputeSignature(cmsSigner, false);

//                //adaugam TSA
//                //mesajul tsa se adauga la mesajul semnat fara marca temporala ca atribut nesemnat
//                byte[] signedMessage = signedCms.Encode();
//                signedCms.Decode(signedMessage);

//                //de optimizat acesta bucata
//                //nu avem functie in .NET 2.0 pentru si.GetSignature() ce are lungimea de 128 bytes

//                Org.BouncyCastle.Cms.CmsSignedData sd = new Org.BouncyCastle.Cms.CmsSignedData(signedMessage);

//                byte[] timeStampHash = null;

//                foreach (Org.BouncyCastle.Cms.SignerInformation si in sd.GetSignerInfos().GetSigners())
//                    timeStampHash = ComputeHash(si.GetSignature());

//                //timeStampHash = si.GetSignature();// ComputeHash(si.GetSignature());

//                byte[] timeStampToken = null;

//                //da eroare inseamna ca marca temporala nu este corecta
//                try
//                {
//                    //timeStampToken = X509Utils.GetTimestampToken(TSAServer, null, null, timeStampHash, tsaCert, comboBoxTSAPolicy.Text);

//                    timeStampToken = GetTimestampToken(TSAServer, username, password, timeStampHash, tsaCert, TSAPolicyOID);

//                }
//                catch (Exception ex)
//                {
//                    //atentionare semnare
//                    //se va atasa semnatura fara timestamping
//                    DialogResult res = MessageBox.Show(ex.Message + StringEN.MessageBoxNoTSA, StringEN.MessageBoxWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

//                    //fara TSA
//                    if (res == DialogResult.Yes)
//                    {
//                        //this.Cursor = Cursors.Arrow;

//                        timestampDocument = false;

//                        return signedMessage;
//                    }

//                    //renuntam total
//                    if (res == DialogResult.No)
//                    {
//                        //this.Cursor = Cursors.Arrow;

//                         FormPDFSigner.cancelSign = true;

//                        //returnam eroare
//                        return null;
//                    }
//                }

//                //daca s-a ajuns aici marca temporala este valida

//                //adaugam ca atribut nesemnat marca temporala
//                cmsSigner.UnsignedAttributes.Add(new System.Security.Cryptography.AsnEncodedData(X509Utils.ID_TIME_STAMP_TOKEN, timeStampToken));

//                //refacem semnatura pentru a include atributul nesemnat
//                signedCms.ComputeSignature(cmsSigner, false);

//                return signedCms.Encode();
//            }
//            catch (Exception ex)
//            {
//                //this.Cursor = Cursors.Arrow;
//                MessageBox.Show(ex.Message, StringEN.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return null;
//            }


//            //    //da eroare inseamna ca marca temporala nu este corecta
//            //    timeStampToken = GetTimestampToken(TSAServer, username, password, timeStampHash, tsaCert, TSAPolicyOID);



//            //    //daca s-a ajuns aici marca temporala este valida

//            //    //adaugam ca atribut nesemnat marca temporala
//            //    cmsSigner.UnsignedAttributes.Add(new System.Security.Cryptography.AsnEncodedData(ID_TIME_STAMP_TOKEN, timeStampToken));

//            //    //refacem semnatura pentru a include atributul nesemnat
//            //    signedCms.ComputeSignature(cmsSigner, false);

//            //    return signedCms.Encode();
//            //}
//            //catch (Exception ex)
//            //{
//            //    throw new Exception(ex.Message);
//            //}

//        }

//        private static byte[] GetTimestampToken(string tsaURL, string tsaUserName, string tsaPassword, byte[] imprint, System.Security.Cryptography.X509Certificates.X509Certificate2 signerCert, string TSAPolicy)
//        {
//            try
//            {
//                TimeStampRequestGenerator tsqGenerator = new TimeStampRequestGenerator();

//                tsqGenerator.SetCertReq(true);

//                //tsqGenerator.SetReqPolicy("1.3.6.1.4.1.601.10.3.1");

//                //a fost scoasa deoarece Adobe nu o pune
//                //tsqGenerator.SetReqPolicy(TSAPolicy);

//                BigInteger nonce = BigInteger.ValueOf(DateTime.Now.Ticks);

//                TimeStampRequest request = tsqGenerator.Generate("1.3.14.3.2.26", imprint, nonce);

//                byte[] requestBytes = request.GetEncoded();

//                byte[] responseBytes = GetTSAResponse(tsaURL, tsaUserName, tsaPassword, requestBytes, signerCert);


//                TimeStampResponse response = new TimeStampResponse(responseBytes);

//                response.Validate(request);

//                object failure = response.GetFailInfo();

//                int value = (failure == null) ? 0 : 1;

//                if (value != 0)
//                {
//                    //throw new Exception("Invalid TSA '" + tsaURL + "' response, code " + value);
//                    throw new Exception(StringEN.invalidTSAResponse);

//                }

//                TimeStampToken tsToken = response.TimeStampToken;


//                //obtinerea certificatelor din raspuns
//                //IX509Store certs = tsToken.GetCertificates("Collection");
//                //X509CertStoreSelector ff = new X509CertStoreSelector();
//                //ArrayList fff = (ArrayList)certs.GetMatches(new X509CertStoreSelector());
//                //int i = 1;
//                //foreach (X509Certificate f in fff)
//                //{
//                //    //System.Windows.Forms.MessageBox.Show(f.IssuerDN.ToString());
//                //    File.WriteAllBytes("c:\\" + i.ToString() + ".cer", f.GetEncoded());
//                //    i++;
//                //}

//                if (tsToken == null)
//                {
//                    throw new Exception("TSA '" + tsaURL + "' failed to return time stamp token");
//                }

//                return tsToken.GetEncoded();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }

//        }

//        private static byte[] GetTSAResponse(string tsaURL, string tsaUserName, string tsaPassword, byte[] requestBytes, System.Security.Cryptography.X509Certificates.X509Certificate2 tsaCert)
//        {

//            try
//            {
//                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(tsaURL);
//                //request.Timeout = 5000; - nare ciniun efect
//                request.ContentType = "application/timestamp-query";
//                request.ContentLength = requestBytes.Length;
//                request.Method = "POST";

//                // if (tsaURL.Contains("ica.cz") == true)
//                ///   request.ClientCertificates.Add(tsaCert);
//                ///   

//                if (tsaCert != null)
//                    request.ClientCertificates.Add(tsaCert);

//                if ((tsaUserName != null) && (tsaUserName != ""))
//                {

//                    String userPassword = tsaUserName + ":" + tsaPassword;
//                    CredentialCache credCache = new CredentialCache();

//                    credCache.Add(new Uri(tsaURL), "Basic",
//                              //new NetworkCredential(tsaUserName, tsaPassword, tsaURL));
//                              //nu merge in unele cazuri
//                              new NetworkCredential(tsaUserName, tsaPassword));
//                    request.Credentials = credCache;
//                };

//                Stream requestStream = request.GetRequestStream();

//                requestStream.Write(requestBytes, 0, requestBytes.Length);

//                requestStream.Close();

//                WebResponse response = request.GetResponse();

//                Stream resStream = response.GetResponseStream();

//                /*StreamReader reader = new StreamReader(resStream); 

//                string debugResp = reader.ReadToEnd(); 

//                Debug.Write(debugResp);*/

//                MemoryStream ms = new MemoryStream();

//                byte[] responseBytes;
//                byte[] buffer = new byte[4096];

//                using (MemoryStream memoryStream = new MemoryStream())
//                {
//                    int count = 0;
//                    do
//                    {
//                        count = resStream.Read(buffer, 0, buffer.Length);
//                        memoryStream.Write(buffer, 0, count);

//                    } while (count != 0);

//                    responseBytes = memoryStream.ToArray();

//                }

//                response.Close();

//                return responseBytes;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }

//        }

//        public static void Sign(string inputFile, string outputFile)
//        {
//            PdfSignatureAppearance sap;
//            PdfDictionary dic2;
//            PdfReader reader;
//            FileStream writer = null;

//            try
//            {
//                if (File.Exists(inputFile) == false)
//                    throw new Exception("Input file does not exists!");

//                reader = new PdfReader(inputFile);

//                if (doNotSignIsSigned == true)
//                {
//                    //acesta verifica daca mesajul este semnat
//                    AcroFields af = reader.AcroFields;
//                    ArrayList names = af.GetSignatureNames();
//                    if (names.Count > 0)
//                        throw new Exception("The document is already signed!");
//                }

//                if (signingCertificate == null)
//                    throw new Exception("Sigining certificate is not set");

//                Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
//                Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] { cp.ReadCertificate(signingCertificate.RawData) };


//                writer = new FileStream(outputFile, FileMode.Create, FileAccess.Write);

//                PdfStamper stp = PdfStamper.CreateSignature(reader, writer, '\0', null, true);

//                sap = stp.SignatureAppearance;

//                //asta e introdusa - se pare ca nu merge cu diacritice
//                //sap.Layer2Font = new iTextSharp.text.Font(4, -10, 0);
//                //BaseFont arial =  BaseFont.CreateFont("C:\\WINDOWS\\FONTS\\times.TTF",BaseFont.CP1252,BaseFont.NOT_EMBEDDED);
//                //sap.Layer2Font = new iTextSharp.text.Font(arial, -10);

//                //MessageBox.Show(File.Exists("%windir%\\fonts\\arial.ttf").ToString());
//                //BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA "%windir%\\fonts\\arial.ttf",
//                //pentru a include diacritice

//                try
//                {
//                    BaseFont signatureFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.EMBEDDED);
//                    sap.Layer2Font = new iTextSharp.text.Font(signatureFont, -10);
//                }
//                catch
//                {
//                }


//                //semnatura simpla
//                //if (basicSignature == true)
//                //  {
//                //ultima pagina
//                if (signaturePage == int.MaxValue)
//                    signaturePage = reader.NumberOfPages;

//                //locatia semnaturii
//                //                    location = comboBoxBasicSignaturePosition.SelectedIndex;

//                //  }

//                ////semnatura avansata
//                //if (basicSignature == false)
//                //    if (signaturePage < 1)
//                //        signaturePage = 1;



//                iTextSharp.text.Rectangle r = reader.GetPageSize(1);


//                //pentru includerea imaginii in semnatura

//                //if (checkBoxIncludeImage.Checked == true)
//                //{
//                //    //setam imaginea
//                //    iTextSharp.text.Jpeg img = new Jpeg(Path.GetDirectoryName(Application.ExecutablePath) + "\\semnatura.jpg");
//                //    sap.Image = img;
//                //}

//                if (showSignature == true)
//                {

//                    //simple signature position
//                    if (basicSignature == true)
//                    {
//                        int startX = 50;
//                        int startY = 50;
//                        int endX = 150;
//                        int endY = 100;

                        

//                        //dreapta sus
//                        if (basicSignaturePosition == 0)
//                            sap.SetVisibleSignature(new iTextSharp.text.Rectangle(r.Width - endX, r.Height - startY, r.Width - startX, r.Height - endY), signaturePage, null);

//                        //stanga sus
//                        if (basicSignaturePosition == 1)
//                            sap.SetVisibleSignature(new iTextSharp.text.Rectangle(startX, r.Height - startY, endX, r.Height - endY), signaturePage, null);

//                        //dreapta jos
//                        if (basicSignaturePosition == 2)
//                            sap.SetVisibleSignature(new iTextSharp.text.Rectangle(r.Width - endX, startY, r.Width - startX, endY), signaturePage, null);

//                        //stanga jos
//                        if (basicSignaturePosition == 3)
//                            sap.SetVisibleSignature(new iTextSharp.text.Rectangle(startX, startY, endX, endY), signaturePage, null);
//                    }


//                    //advance signature position
//                    if (basicSignature == false)
//                        sap.SetVisibleSignature(signatureRectangle, signaturePage, null);

//                    //sap.SetVisibleSignature(new iTextSharp.text.Rectangle(topLeft, topRight, bottomLeft, bottomRight), signaturePage, null);
//                }

//                //fus orar - nu e nevoie
//                //TimeSpan offspan = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
//                //scadem fusul orar
//                sap.SignDate = DateTime.Now;

//                sap.SetCrypto(null, chain, null, PdfSignatureAppearance.WINCER_SIGNED);
//                //sap.SetCrypto(null, chain, null, null);

//                try
//                {
//                    sap.Contact = signingCertificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.EmailName, false);
//                }
//                catch
//                {
//                }

//                //realizam localizarea
//                //sap.SignDigitallySignedBy = "Signé par ";
//                //sap.SignDateTime = "Data sig: ";
//                //sap.SignDateFormat = "yyyy.MM.dd HH:mm";

//                ///public string SignDateFormat = "yyyy.MM.dd HH:mm:ss zzz";
//                //sap.SignReason = "Raison: ";
//                //sap.SignLocation = "Emplacement: ";

//                //realizam localizarea

//                //sap.SignDigitallySignedBy = StringEN.signDigitallySignedBy;
//                //sap.SignDateTime = StringEN.signDateTime;
//                //sap.SignDateFormat = StringEN.signDateFormat;
//                //sap.SignReason = StringEN.signReason;
//                //sap.SignLocation = StringEN.signLocation;


//                sap.SignDigitallySignedBy = signedBy + " ";

//                sap.SignDateTime = signatureDate + " ";

//                sap.SignDateFormat = dateFormat;

//                sap.SignReason = reasonText + " ";

//                sap.SignLocation = locationText + " ";


//                if (signingReason.Length > 0)
//                    sap.Reason = signingReason;

//                if (signingLocation.Length > 0)
//                    sap.Location = signingLocation;

//                //daca e activa nu se mai vede semnul intrebarii mare
//                sap.Acro6Layers = true;

//                //seamnarea folosind imagine
//                //sap.SignatureGraphic = iTextSharp.text.Image.GetInstance("c:\\signature.jpg");
//                //sap.Render = PdfSignatureAppearance.SignatureRender.GraphicAndDescription;

//                sap.Render = PdfSignatureAppearance.SignatureRender.Description;

//                PdfSignature dic = new PdfSignature(PdfName.ADOBE_PPKMS, PdfName.ADBE_PKCS7_SHA1);

//                dic.Date = new PdfDate(sap.SignDate);

//                //optimizare .NET
//                //dic.Name = PdfPKCS7.GetSubjectFields(chain[0]).GetField("CN");

//                try
//                {
//                    dic.Name = signingCertificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, false);
//                }
//                catch
//                {
//                }

//                if (sap.Reason != null)
//                    dic.Reason = sap.Reason;

//                if (sap.Location != null)
//                    dic.Location = sap.Location;

//                if (sap.Contact != null)
//                    dic.Contact = sap.Contact;

//                sap.CryptoDictionary = dic;

//                int csize = 4000 * 4; //*4 pentru a incapea marca temporala
//                //int csize = 4000;
//                Hashtable exc = new Hashtable();
//                //exc.Add(PdfName.CONTENTS, 48 * 2 + 2);

//                exc[PdfName.CONTENTS] = csize * 2 + 2;
////                sap.PreClose(exc);
//                sap.PreClose(exc,reader.NumberOfPages);

//                System.Security.Cryptography.HashAlgorithm sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();

//                Stream s = sap.RangeStream;

//                int read = 0;
//                byte[] buff = new byte[8192];
//                while ((read = s.Read(buff, 0, 8192)) > 0)
//                {
//                    sha.TransformBlock(buff, 0, read, buff, 0);
//                }
//                sha.TransformFinalBlock(buff, 0, 0);

//                //byte[] pk = SignMsg(sha.Hash, card);

//                byte[] pk = null;


//                /*
//                 *         //GroupBox Timestamping
//        public bool timestampDocument = false;
//        public string timeStampingServer = null;
//        public string TSAPolicy = "1.3.6.1.4.1.601.10.3.1";
//        public bool TSARequiresLogOn = false;
//        public string UserName = null;
//        public string Password = null;
//        public bool TSARequiresCertificate = false;
//        public System.Security.Cryptography.X509Certificates.X509Certificate2 TSACertificate = null;
//                 */




//                ////cu TSA
//                if (timestampDocument == true)
//                {
//                    if (TSARequiresCertificate == true)
//                    {
//                        if (TSACertificateLogOn == null)
//                            throw new Exception("TSA log on certificate is not set");

//                        pk = SignMsgTSA(sha.Hash, signingCertificate, timeStampingServer, TSACertificateLogOn, UserName, Password);
//                    }
//                    else
//                        pk = SignMsgTSA(sha.Hash, signingCertificate, timeStampingServer, null, UserName, Password);
//                }
//                else
//                    pk = SignMsg(sha.Hash, signingCertificate);

//                if (pk == null)
//                {
//                    reader.Close();
//                    writer.Close();
//                    sap = null;

//                    try
//                    {
//                        File.Delete(outputFile);
//                    }
//                    catch
//                    {
//                    }

//                    throw new Exception("Signing operation failure!");
//                }

//                byte[] outc = new byte[csize];

//                dic2 = new PdfDictionary();

//                Array.Copy(pk, 0, outc, 0, pk.Length);

//                dic2.Put(PdfName.CONTENTS, new PdfString(outc).SetHexWriting(true));

//                sap.Close(dic2);

//                reader.Close();
//                writer.Close();
//            }
//            catch (Exception ex)
//            {

//                try
//                {
//                    reader = null;
//                    sap = null;
//                    writer.Close();
//                }
//                catch
//                {
//                }

//                try
//                {
//                    File.Delete(outputFile);
//                }
//                catch
//                {
//                }

//                //pentru a colora diferit exceptiile aruncate de TSA
//                if (ex.TargetSite.Name.Contains("SignMsgTSA"))
//                    throw new Exception(StringEN.TSAError + Path.GetFileName(inputFile) + ". " + ex.Message);
//                else
//                    throw new Exception(StringEN.MessageBoxFileError + Path.GetFileName(inputFile) + ". " + ex.Message);
//            }
//        }

//    }
//}
