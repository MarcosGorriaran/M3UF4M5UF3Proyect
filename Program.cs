namespace CRUMGame
{
    public class CRUMGameDriver
    {
        public static void Main()
        {
            const string PlayOption = "Jugar";
            const string ExitOption = "Salir";
            const string AskOption = "Elige una de las opciones: ";
            const string AskRole = "Elige un rol que asumir: ";
            const string AskName = "Cual es tu nombre: ";
            const string WrongFormatError = "El formato de la opcion elegida no es valido";
            const string OptionOutOfRangeError = "La opcion esta fuera del rango permitido";
            const string SceneIntro = "Hola, {0}! El 112 ha recibido una llamada de aviso de un ejemplar a rescatar.";
            const string ShowTableText = "Los datos del rescate son los siguiente:";
            const string ShowInfoText = "Y estos son los datos del animal:";
            const string SendCrumOption = "Enviar al CRUM";
            const string TreatNow = "Tratar ahora";
            const string AskActionOption = "Que haras para rescatar a este animal: ";
            const string PositiveFeedback = "Bien, el GA ha sido reducido hasta el {0}, el ejemplar puede volver a su habitat. Tu experiencia ha aumentado en {1}";
            const string NegativeFeedback = "Vaya, el GA ahora es del {0}, el tratamiento no ha sido lo suficientemente efectivo. Tu experiencia ha sido reducido en {1}";
            const string ActualXP = "Ahora su experiencia es de {0}";
            const char SectionSpliterChar = '-';
            const int VetOption = 1;
            const int TechOption = 2;
            const int MenuMinVal = 1;
            const int FirstMenuMaxVal = 2;
            const int TreatMentMaxVal = 2;
            const int TurtleOption = 1;
            const int BirdOption = 2;
            const int MammalOption = 3;
            const int LimitFeedbackResult = 5;
            Random rnd = new Random();
            Player playerStats=new Player();
            MarineTurtle turtle=new MarineTurtle((int)rnd.NextInt64(MarineTurtle.IDMinLimit,MarineTurtle.IDMaxLimit),(int)rnd.NextInt64(MarineTurtle.ARMinLimit, MarineTurtle.ARMaxLimit));
            WaterBird bird= new WaterBird((int)rnd.NextInt64(WaterBird.IDMinLimit, WaterBird.IDMaxLimit), (int)rnd.NextInt64(WaterBird.ARMinLimit, WaterBird.ARMaxLimit));
            WaterMammal mammal = new WaterMammal((int)rnd.NextInt64(WaterMammal.IDMinLimit, WaterMammal.IDMaxLimit), (int)rnd.NextInt64(WaterMammal.ARMinLimit, WaterMammal.ARMaxLimit));
            string errorMsg;
            int option=0;
            int gameOption=0;
            int actualGA=0;
            bool error;
            bool feedback;
            
            do
            {
                do
                {
                    error = false;
                    try
                    {
                        Console.Write(BuildMenu(AskOption, PlayOption, ExitOption));
                        option = Convert.ToInt32(Console.ReadLine());
                        error = option < MenuMinVal || option > FirstMenuMaxVal;
                        if(error)
                        {
                            Console.WriteLine(OptionOutOfRangeError);
                        }
                    }
                    catch(FormatException) 
                    {
                        error = true;
                        Console.WriteLine(WrongFormatError);
                    }
                    Console.WriteLine(new string(SectionSpliterChar,Console.WindowWidth));
                } while (error);
                if(option == MenuMinVal)
                {
                    do
                    {
                        error = false;
                        try
                        {
                            Console.Write(BuildMenu(AskRole, Player.VetRole, Player.TechRole));
                            gameOption = Convert.ToInt32(Console.ReadLine());
                            switch (gameOption)
                            {
                                case VetOption:
                                    playerStats.Role = Player.VetRole;
                                    break;
                                case TechOption:
                                    playerStats.Role = Player.TechRole;
                                    break;
                                default:
                                    error = true;
                                    Console.WriteLine(OptionOutOfRangeError);
                                    break;
                            }
                        }
                        catch (FormatException)
                        {
                            error = true;
                            Console.WriteLine(WrongFormatError);
                        }
                    } while (error);
                    Console.Write(AskName);
                    playerStats.Name = Console.ReadLine()??"";

                    Console.WriteLine(SceneIntro, playerStats.Name);
                    Console.WriteLine(ShowTableText);

                    feedback = false;
                    switch ((int)rnd.NextInt64(TurtleOption, MammalOption+1))
                    {
                        case TurtleOption:
                            Console.WriteLine(turtle.BuildRescueTable().toTableString());
                            Console.WriteLine(ShowInfoText);
                            Console.WriteLine(turtle.BuildInfoTable().toTableString());
                            error = false;
                            do
                            {
                                try
                                {
                                    Console.Write(BuildMenu(AskActionOption, SendCrumOption, TreatNow));
                                    gameOption = Convert.ToInt32(Console.ReadLine());
                                    error = gameOption < MenuMinVal || gameOption > TreatMentMaxVal;
                                    if (error)
                                    {
                                        Console.WriteLine(OptionOutOfRangeError);
                                    }
                                    
                                }
                                catch (FormatException)
                                {
                                    error = true;
                                    Console.WriteLine(WrongFormatError);
                                }
                            } while (error);
                            turtle.CalcNewAR(gameOption-1);
                            feedback = turtle.AfectionRate < LimitFeedbackResult;
                            actualGA = turtle.AfectionRate;
                            break;
                        case BirdOption:
                            Console.WriteLine(bird.BuildRescueTable().toTableString());
                            Console.WriteLine(ShowInfoText);
                            Console.WriteLine(bird.BuildInfoTable().toTableString());
                            error = false;
                            do
                            {
                                try
                                {
                                    Console.Write(BuildMenu(AskActionOption, SendCrumOption, TreatNow));
                                    gameOption = Convert.ToInt32(Console.ReadLine());
                                    error = gameOption < MenuMinVal || gameOption > TreatMentMaxVal;
                                    if (error)
                                    {
                                        Console.WriteLine(OptionOutOfRangeError);
                                    }
                                }
                                catch (FormatException)
                                {
                                    error = true;
                                    Console.WriteLine(WrongFormatError);
                                }
                            } while (error);
                            bird.CalcNewAR(gameOption - 1);
                            feedback = bird.AfectionRate < LimitFeedbackResult;
                            actualGA = bird.AfectionRate;
                            break;
                        case MammalOption:
                            Console.WriteLine(mammal.BuildRescueTable().toTableString());
                            Console.WriteLine(ShowInfoText);
                            Console.WriteLine(mammal.BuildInfoTable().toTableString());
                            error = false;
                            do
                            {
                                try
                                {
                                    Console.Write(BuildMenu(AskActionOption, SendCrumOption, TreatNow));
                                    gameOption = Convert.ToInt32(Console.ReadLine());
                                    error = gameOption < MenuMinVal || gameOption > TreatMentMaxVal;
                                    if (error)
                                    {
                                        Console.WriteLine(OptionOutOfRangeError);
                                    }
                                }
                                catch (FormatException)
                                {
                                    error = true;
                                    Console.WriteLine(WrongFormatError);
                                }
                            } while (error);
                            mammal.CalcNewAR(gameOption - 1);
                            feedback = mammal.AfectionRate < LimitFeedbackResult;
                            actualGA = mammal.AfectionRate;
                            break;
                    }
                    playerStats.XPFeedback(feedback);
                    Console.WriteLine(feedback ? PositiveFeedback:NegativeFeedback, actualGA,feedback ? Player.PositiveFeedback:Player.NegativeFeedback);
                    Console.WriteLine(ActualXP,playerStats.XP);
                    Console.WriteLine(new string(SectionSpliterChar, Console.WindowWidth));
                }
            } while (option!=FirstMenuMaxVal);
        }
        public static string BuildMenu(string askMsg, params string[] contents)
        {
            string result = "";
            for(int i=0; i<contents.Length; i++)
            {
                result+=$"{i+1}. {contents[i]}{Environment.NewLine}";
            }
            return result+askMsg;
        }
    }
}