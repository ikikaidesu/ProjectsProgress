using System;
using System.Threading;
using System.Diagnostics;

namespace tennis
{
    class Program
    {
        // игра
        // размеры окна
        public static int widthsize = 45;
        public static int heightsize = 25;
        // множитель размеров окна
        public static int multipliersize = 2;
        // цвет текста
        public static ConsoleColor textcolor = ConsoleColor.White;
        // кадр в миллисекунду
        public static int FrameMS = 100;
        // барьер 
        // символ 
        public static char barrierchar = '█';
        // цвет
        public static ConsoleColor barriercolor = ConsoleColor.DarkGray;
        // бот
        // активация ( для игры против него)
        public static bool activatebot = false;
        // его имя 
        public static string botname = "bot";
        // сложность ( чем ближе к 1 тем сложнее)
        public static double botdifficult = 1.01;
        // игрок
        // количество игроков стартовое
        public static int playerscount = 1;
        // массив стартовых имен
        public static string[] playersname = new string[2] {"player1", botname };
        // очки игроков
        public static int playeronescore = 0;
        public static int playertwoscore = 0;
        // символ игроков(символ ракетки)
        public static char playerchar = '#';
        // цвета игроков
        // слева игрок
        public static ConsoleColor playeronecolor = ConsoleColor.Red;
        // справа игрок
        public static ConsoleColor playertwocolor = ConsoleColor.Blue;
        // размер ракетки
        public static int racketlength = 8;
        // мячик
        // символ
        public static char ballchar = 'O';
        // цвет
        public static ConsoleColor ballcolor = ConsoleColor.White;
        // функция при запуске для корректировки окна
        static void Main(string[] args)
        {
            // устанавливаем размер консоли
            Console.SetWindowSize(widthsize* multipliersize, heightsize* multipliersize);
            // устанавливаем размер буфера
            Console.SetBufferSize(widthsize* multipliersize, heightsize* multipliersize);
            // запускаем игру
            startgame();
            Console.ReadKey();
        }
        // функция отрисовки барьера
        public static void barrier()
        {
            // ширина 
            for (int i = 0; i < widthsize*multipliersize; i++)
            {
                // вверх
                new Pixel(i, 1, barrierchar, barriercolor);
                // низ
                new Pixel(i, heightsize*multipliersize-2, barrierchar, barriercolor);
            }
            // по длине не вижу делать смысла ведь так будет понятно что сзади вас "ворота"
            // которые вы должны защищать
        }
        // настройки при старте игры
        public static void startgame()
        {
            //Спрашиваем количество игроков(1/2)
            Console.WriteLine("Выберите режим игры: одиночный или дуэль? (1/2)");
            // получаем клавишу
            ConsoleKey key = Console.ReadKey(true).Key;
            // ожидаем пока игок не нажмет на клавишу 1 или 2
            while (key != ConsoleKey.D1 && key != ConsoleKey.D2)
            {
                key = Console.ReadKey(true).Key;
            }
            // если игрок выбрал соло(против бота)
            if (key == ConsoleKey.D1)
            {
                // спрашиваем имя игрока
                Console.Write("Имя игрока: ");
                // заполняем массив именем
                playersname[0] = Console.ReadLine();
                // устанавливаем кол-во игроков равное 1
                playerscount = 1;
            }
            // если игрок выбрал дуэль(2 игрока)
            else  if (key == ConsoleKey.D2)
            {
                //Спрашиваем количество игроков(1/2)
                Console.WriteLine("Против бота или игрока? (1/2)");
                // получаем клавишу
                key = Console.ReadKey(true).Key;
                // ожидаем пока игок не нажмет на клавишу 1 или 2
                while (key != ConsoleKey.D1 && key != ConsoleKey.D2)
                {
                    key = Console.ReadKey(true).Key;
                }
                // если нажал 1
                if (key == ConsoleKey.D1)
                {
                    // спрашиваем имя игрока
                    Console.Write("Имя игрока: ");
                    // заполняем массив именем
                    playersname[0] = Console.ReadLine();
                    // устанавливаем кол-во игроков равное 2
                    playerscount = 2;
                    // активируем бота
                    activatebot = true;
                }
                // если игрок нажал 2
                else if(key == ConsoleKey.D2)
                {
                    // устанавливаем кол-во игроков равное 2
                    playerscount = 2;
                    // спрашиваем имя игрока 1
                    Console.Write("Имя первого игрока: ");
                    // заполняем массив именем
                    playersname[0] = Console.ReadLine();
                    // спрашиваем имя игрока 2
                    Console.Write("Имя второго игрока: ");
                    // заполняем массив именем
                    playersname[1] = Console.ReadLine();
                }
            }
            // очищаем консоль
            Console.Clear();
            // запускаем соответствующий режим
            // если игроков 1
            if (playerscount == 1)
            {
                SoloGame();
            }
            // если игроков 2 и бот активирован
            else if (playerscount == 2 && activatebot)
            {
                DuoBotGame();
            }
            // если игроков 2 и бот не активирован
            else
            {
                DuoGame();
            }
        }
        // функция соло игры
        public static void SoloGame()
        {
            //убираем видимость курсора
            Console.CursorVisible = false;
            // выводим информацию об игроке
            SoloScore();
            // создаем игрока
            Player player = new Player((widthsize * multipliersize - racketlength) / 2, heightsize * multipliersize - 5, playerchar, playeronecolor, 1);
            // создаем мячик
            Ball ball = new Ball((widthsize * multipliersize - racketlength/2) / 2 + 1, heightsize * multipliersize - 7, ballchar, ballcolor, 1);
            // запускаем нашу игру
            // создаем таймер
            Stopwatch watcher = new Stopwatch();
            // запускаем игру через цикл
            while (true)
            {
                // запускаем таймер
                watcher.Restart();
                // пока таймер меньше таймера кадров
                while (watcher.ElapsedMilliseconds < FrameMS)
                {
                    // спрашиваем движение у игрока
                    player.Move(1);
                }
                // двигаем мяч
                ball.Move(player);
                // если мяч ниже игрока
                if (ball.ball.y > heightsize * multipliersize - 5)
                {
                    // очищаем игрока
                    player.Clear();
                    // очищаем мяч
                    ball.ball.Clear();
                    // выводим результаты игры
                    Winner(playersname[0], 1, playeronescore);
                }
            }
        }
        // запуск дуэли против бота
        public static void DuoBotGame()
        {
            // создаем барьер
            barrier();
            //убираем видимость курсора
            Console.CursorVisible = false;
            // выводим информацию о левом игроке
            LeftScore();
            // выводим информацию о правом игроке
            RightScore();
            // создаем игрока 
            Player player = new Player(1, heightsize / 2 - racketlength, playerchar, playeronecolor, 2);
            // создаем бота
            Player bot = new Player(widthsize * multipliersize - 2, heightsize / 2 - racketlength, playerchar, playertwocolor, 2);
            // создаем мячик
            Ball ball = new Ball(widthsize * multipliersize / 2, heightsize * multipliersize / 2, ballchar, ballcolor, 2);
            // запускаем нашу игру
            // создаем таймер
            Stopwatch watcher = new Stopwatch();
            // создаем отдельный таймер для бота
            Stopwatch botMoveTimer = new Stopwatch();
            // Создаем и запускаем отдельный поток для метода Move у объекта ball
            botMoveTimer.Restart();
            // запускаем игру через цикл
            while (true)
            {
                // запускаем таймер
                watcher.Restart();
                // пока таймер меньше таймера кадров
                while (watcher.ElapsedMilliseconds < FrameMS)
                {
                    // спрашиваем движение у игрока
                    player.Move(2);
                    // двигаем бота
                    if (botMoveTimer.ElapsedMilliseconds >= FrameMS*botdifficult)
                    {
                        // если бот выше мяча
                        if (bot.racket[bot.racket.Length / 2].y < ball.ball.y)
                        {
                            // двигаем вниз
                            bot.BotMove('S');
                        }
                        // если бот ниже мяча
                        else
                        {
                            // двигаем вверх
                            bot.BotMove('W');
                        }
                        // перезапускаем таймер бота 
                        botMoveTimer.Restart();
                    }
                }
                // двигаем мяч
                ball.Move(player, bot);
                // если попали в ворота игрока слева
                if (ball.ball.x <= 0)
                {
                    // увеличиваем счет правого так как он забил
                    playertwoscore++;
                    // выводим новую информацию
                    RightScore();
                    // стираем мячик
                    ball.ball.Clear();
                    // создаем новый мяч заново чтобы он заспавнился в центре
                    ball = new Ball(widthsize * multipliersize / 2, heightsize * multipliersize / 2, ballchar, ballcolor, 2);
                }
                // если попали в ворота игрока справа
                else if (ball.ball.x >= widthsize*multipliersize-1)
                {
                    // увеличиваем счет левого так как он забил
                    playeronescore++;
                    // выводим новую информацию
                    LeftScore();
                    // стираем мячик
                    ball.ball.Clear();
                    // создаем новый мяч заново чтобы он заспавнился в центре
                    ball = new Ball(widthsize * multipliersize / 2, heightsize * multipliersize / 2, ballchar, ballcolor, 2);
                }
                // если кто-то набрал 5 очков, то он победил
                if (playeronescore == 5 || playertwoscore == 5)
                {
                    // очищаем мяч
                    ball.ball.Clear();
                    // очищаем игрока
                    player.Clear();
                    // очищаем бота
                    bot.Clear();
                    // выводим информацию о победе
                    Winner(playeronescore == 5 ? playersname[0] : playersname[1], 2);
                }
            }
        }
        // функция дуэли
        public static void DuoGame()
        {
            // создаем барьер
            barrier();
            //убираем видимость курсора
            Console.CursorVisible = false;
            // выводим информацию о левом игроке
            LeftScore();
            // выводим информацию о правом игроке
            RightScore();
            // создаем игрока 1
            Player player1 = new Player(1, heightsize / 2 - racketlength, playerchar, playeronecolor, 2);
            // создаем игрока 2
            Player player2 = new Player(widthsize * multipliersize - 2, heightsize / 2 - racketlength, playerchar, playertwocolor, 2);
            // создаем мячик
            Ball ball = new Ball(widthsize * multipliersize / 2, heightsize * multipliersize / 2, ballchar, ballcolor, 2);
            // запускаем нашу игру
            // создаем таймер
            Stopwatch watcher = new Stopwatch();
            // запускаем игру через цикл
            while (true)
            {
                // запускаем таймер
                watcher.Restart();
                // пока таймер меньше таймера кадров
                while (watcher.ElapsedMilliseconds < FrameMS)
                {
                    // спрашиваем движение у игрока 1
                    player1.Move(2);
                    // спрашиваем движение у игрока 2
                    player2.Move(2);
                }
                // двигаем мяч
                ball.Move(player1, player2);
                // если попали в ворота игрока слева
                if (ball.ball.x <= 0)
                {
                    // увеличиваем счет правого так как он забил
                    playertwoscore++;
                    // выводим новую информацию
                    RightScore();
                    // стираем мячик
                    ball.ball.Clear();
                    // создаем новый мяч заново чтобы он заспавнился в центре
                    ball = new Ball(widthsize * multipliersize / 2, heightsize * multipliersize / 2, ballchar, ballcolor, 2);
                }
                // если попали в ворота игрока справа
                else if (ball.ball.x >= widthsize * multipliersize - 1)
                {
                    // увеличиваем счет правого так как он забил
                    playeronescore++;
                    // выводим новую информацию
                    LeftScore();
                    // стираем мячик
                    ball.ball.Clear();
                    // создаем новый мяч заново чтобы он заспавнился в центре
                    ball = new Ball(widthsize * multipliersize / 2, heightsize * multipliersize / 2, ballchar, ballcolor, 2);
                }
                // если кто-то набрал 5 очков, то он победил
                if (playeronescore == 5 || playertwoscore == 5)
                {
                    // очищаем мяч
                    ball.ball.Clear();
                    // очищаем игрока 1
                    player1.Clear();
                    // очищаем игрока 2
                    player2.Clear();
                    // выводим информацию о победе
                    Winner(playeronescore == 5 ? playersname[0] : playersname[1], 3);
                }
            }
        }
        // фунцкия обновление счета левого игрока
        public static void LeftScore()
        {
            // ставим цвет
            Console.ForegroundColor = textcolor;
            // ставим цвет текста перед его выводом
            Console.ForegroundColor = textcolor;
            // устанавливаем курсор для вывода информации игрока и бота
            // имя игрока
            Console.SetCursorPosition(1, 0);
            Console.Write(playersname[0]);
            // счет игрока
            // 2(пробел от левой стенки + пробел от имени)+длина ника
            Console.SetCursorPosition(2 + playersname[0].Length, 0);
            // выводим счет
            Console.Write(playeronescore);
        }
        // фунцкия обновление счета правого игрока
        public static void RightScore()
        {
            // ставим цвет
            Console.ForegroundColor = textcolor;
            // имя бота
            // так как имя справа то и отчет с крайней правой точки(ширина*множитель-1(пробел от стенки)-длина имени
            Console.SetCursorPosition(widthsize * multipliersize - 1 - playersname[1].Length, 0);
            Console.Write(playersname[1]);
            // счет бота
            // так как счет справа то и отчет с крайней правой точки
            // (ширина*множитель-2(пробел от стенки+пробел от имени)-длина счета чтобы он всегда был в одном пробеле от имени
            Console.SetCursorPosition(widthsize * multipliersize - 2 - playersname[1].Length - playertwoscore.ToString().Length, 0);
            // выводим счет
            Console.Write(playertwoscore);
        }
        // фунцкия обновление счета игрока в соло режиме
        public static void SoloScore()
        {
            // ставим цвет
            Console.ForegroundColor = textcolor;
            // текст с ником и очками игрока
            string score = $"{playersname[0]} {playeronescore}";
            // перемещаем курсор для вывода информации об игроке
            Console.SetCursorPosition((widthsize * multipliersize - score.Length) / 2, heightsize * multipliersize - 2);
            // выводим счет
            Console.Write(score);
        }
        // функция вывода победителя 
        // gamenumber - номер игры
        // 1 - соло
        // 2 - против бота
        // 3 - против игрока
        public static void Winner(string name, int gamenumber, int score = 0)
        {
            // если режим соло
            if (gamenumber == 1)
            {
                playeronescore = 0;
                // текст при окончании игры
                string[] winnertext = new string[] { "Игра окончена!", $"Ваш счет {playeronescore}", "Сыграть заново?(Y/N)" };
                // выводим текст
                for (int i = 0; i < winnertext.Length; i++)
                {
                    // ставим курсор по центру
                    Console.SetCursorPosition((widthsize * multipliersize - winnertext[i].Length) / 2, heightsize * multipliersize / 2 + i);
                    // выводим текст
                    Console.Write(winnertext[i]);
                }
                // получаем клавишу
                ConsoleKey key = Console.ReadKey(true).Key;
                // ожидаем пока игок не нажмет на клавишу 1 или 2
                while (key != ConsoleKey.Y && key != ConsoleKey.N)
                {
                    key = Console.ReadKey(true).Key;
                }
                // если игрок согласился продолжить
                if (key == ConsoleKey.Y)
                {
                    // очищаем консоль
                    Console.Clear();
                    // заново запускаем игру
                    SoloGame();
                }
                // если отказался
                else
                {
                    // очищаем консоль
                    Console.Clear();
                    // переводим его в главное меню
                    startgame();
                }
            }
            // если режим дуэль
            else
            {
                // обнуляем очки
                playeronescore = 0;
                playertwoscore = 0;
                // текст при окончании игры
                string[] winnertext = new string[2] { $"Победил {name}!", "Сыграть заново?(Y/N)" };
                // выводим текст
                for (int i = 0; i < winnertext.Length; i++)
                {
                    // ставим курсор по центру
                    Console.SetCursorPosition((widthsize * multipliersize - winnertext[i].Length) / 2, heightsize * multipliersize / 2 + i);
                    // выводим текст
                    Console.Write(winnertext[i]);
                }
                // получаем клавишу
                ConsoleKey key = Console.ReadKey(true).Key;
                // ожидаем пока игок не нажмет на клавишу 1 или 2
                while (key != ConsoleKey.Y && key != ConsoleKey.N)
                {
                    key = Console.ReadKey(true).Key;
                }
                // если игрок согласился продолжить
                if (key == ConsoleKey.Y)
                {
                    // очищаем консоль
                    Console.Clear();
                    // если режим против бота
                    if (gamenumber == 2)
                    {
                        // запускаем заново режим
                        DuoBotGame();
                    }
                    // если режим против игрока
                    else
                    {
                        // запускаем заново режим
                        DuoGame();
                    }
                }
                // если отказался
                else
                {
                    // очищаем консоль
                    Console.Clear();
                    // переводим игрока в главное меню
                    startgame();
                }
            }
        }
    }
}
