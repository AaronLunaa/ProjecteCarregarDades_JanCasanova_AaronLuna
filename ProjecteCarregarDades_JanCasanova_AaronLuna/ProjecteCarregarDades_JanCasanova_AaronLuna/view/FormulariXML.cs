using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using ProjecteCarregarDades_JanCasanova_AaronLuna.model;
using ProjecteCarregarDades_JanCasanova_AaronLuna.services;

namespace ProjecteCarregarDades_JanCasanova_AaronLuna
{
    public partial class FormulariXML : Form
    {
        public FormulariXML()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Selecciona un fitxer XML";
            openFileDialog1.Filter = "Fitxers XML (*.xml)|*.xml";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nomFitxer = openFileDialog1.FileName;

                // Valida el fitxer XML amb el fitxer DTD
                bool valid = ValidateXmlWithDtd(nomFitxer, "cinema.dtd");

                if (valid)
                {
                    // Crea una instància del XmlManager
                    XmlManager xmlManager = new XmlManager();

                    // Llegeix les pel·lícules del fitxer XML
                    List<Movie> movies = xmlManager.ReadMoviesFromXml(nomFitxer);

                    // Desa les pel·lícules a la base de dades
                    xmlManager.ImportDataToDatabase(nomFitxer);

                    // Mostra un missatge d'èxit o realitza altres accions necessàries
                    MessageBox.Show("Les dades s'han carregat a la base de dades.");
                }
                else
                {
                    // El fitxer XML no és vàlid segons el DTD
                    MessageBox.Show("El fitxer XML no és vàlid segons el DTD.");
                }
            }
        }

        private bool ValidateXmlWithDtd(string xmlFilePath, string dtdFilePath)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                settings.ValidationType = ValidationType.DTD;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

                using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
                {
                    while (reader.Read()) { }
                }

                return true;
            }
            catch (XmlException ex)
            {
                // Hi ha hagut un error de validació
                Console.WriteLine("Error de validació: " + ex.Message);
                return false;
            }
        }
    }
    }
