using System;
using System.Threading;
using System.Windows.Input;

//класс отвечающий за игрока
public class Player
{
    // номер игрока
    public int playernumber;
    // ракетка ( массив из пикселей)
    public Pixel[] racket = new Pixel[tennis.Program.racketlength];
    // создание игрока с отрисовкой
    // стартовая координата X
    // стартовая координата Y
    // Пиксель которым будет выглядеть игрок
    // стартовый цвет 
    // версия игры ( 1 - соло, 2 - дуэль)
    public Player(int X, int Y, char Pixel, ConsoleColor Color, int gameversion)
    {
        // если дуэль
        if (gameversion == 2)
        {
            // создаем игрока и назнчаем номер по цвету
            if (Color == tennis.Program.playeronecolor)
            {
                playernumber = 1;
            }
            else
            {
                playernumber = 2;
            }
            // отрисовываем ракетку по соответствующим координатам идя вниз по Y
            for (int i = 0; i < racket.Length; i++)
            {
                // заполняем массив из частей нашей ракетки 
                racket[i] = new Pixel(X, Y + i, Pixel, Color);
            }
        }
        // для соло игры создаем игрока
        else
        {
            // отрисовываем ракетку по соответствующим координатам идя вправо по X
            for (int i = 0; i < racket.Length; i++)
            {
                // заполняем массив из частей нашей ракетки
                racket[i] = new Pixel(X + i, Y, Pixel, Color);
            }
        }
    }
    // очистка ракетки с поля
    public void Clear()
    {
        // обходим массив пикселей и очищаем
        foreach (var i in racket)
        {
            i.Clear();
        }
    }
    // функция движения
    public void Move(int gameversion)
    {
        // если дуэль
        if (gameversion == 2)
        {
            // если доступно нажатие клавиш
            // это нужно чтобы мяч мог двигаться 
            if (Console.KeyAvailable)
            {
                // для игрока слева
                if (playernumber == 1)
                {
                    // читаем клавишу
                    ConsoleKey key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        // если клавиша W
                        case ConsoleKey.W:
                            // проверка чтобы игрок не выходил за пределы барьера
                            if (racket[0].y > 2)
                            {
                                // очищаем ракетку
                                Clear();
                                // отрисовываем
                                for (int i = 0; i < racket.Length; i++)
                                {
                                    // делаем все ракетки выше
                                    racket[i].y -= 1;
                                    // рисуем по символу
                                    racket[i].Draw();
                                }
                            }
                            break;
                        // если клавиша S
                        case ConsoleKey.S:
                            // проверка чтобы игрок не выходил за пределы барьера
                            if (racket[racket.Length - 1].y < tennis.Program.heightsize * tennis.Program.multipliersize - 3)
                            {
                                // очищаем ракетку
                                Clear();
                                // отрисовываем
                                for (int i = 0; i < racket.Length; i++)
                                {
                                    // делаем все ракетки ниже
                                    racket[i].y += 1;
                                    // рисуем по символу
                                    racket[i].Draw();
                                }
                            }
                            break;
                    }
                }
                // для игрока справа
                else
                {
                    // читаем клавишу
                    ConsoleKey key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        // если клавиша стрелочка вверх
                        case ConsoleKey.UpArrow:
                            // проверка чтобы игрок не выходил за пределы барьера
                            if (racket[0].y > 2)
                            {
                                // очищаем ракетку
                                Clear();
                                // отрисовываем
                                for (int i = 0; i < racket.Length; i++)
                                {
                                    // делаем все ракетки выше
                                    racket[i].y -= 1;
                                    // рисуем по символу
                                    racket[i].Draw();
                                }
                            }
                            break;
                        // если клавиша стрелочка вниз
                        case ConsoleKey.DownArrow:
                            // проверка чтобы игрок не выходил за пределы барьера
                            if (racket[racket.Length - 1].y < tennis.Program.heightsize * tennis.Program.multipliersize - 3)
                            {
                                // очищаем ракетку
                                Clear();
                                // отрисовываем
                                for (int i = 0; i < racket.Length; i++)
                                {
                                    // делаем все ракетки ниже
                                    racket[i].y += 1;
                                    // рисуем по символу
                                    racket[i].Draw();
                                }
                            }
                            break;
                    }
                }
            }
        }
        // если соло режим
        else
        {
            // если доступно нажатие клавиш
            // это нужно чтобы мяч мог двигаться 
            if (Console.KeyAvailable)
            {
                // читаем клавишу
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    // если клавиша А
                    case ConsoleKey.A:
                        // проверка чтобы игрок не выходил за пределы барьера
                        if (racket[0].x > 0)
                        {
                            // очищаем ракетку
                            Clear();
                            // отрисовываем
                            for (int i = 0; i < racket.Length; i++)
                            {
                                // делаем все ракетки левее
                                racket[i].x -= 1;
                                // рисуем по символу
                                racket[i].Draw();
                            }
                        }
                        break;
                    // если клавиша D
                    case ConsoleKey.D:
                        // проверка чтобы игрок не выходил за пределы барьера
                        if (racket[racket.Length - 1].x < tennis.Program.widthsize * tennis.Program.multipliersize - 1)
                        {
                            // очищаем ракетку
                            Clear();
                            // отрисовываем
                            for (int i = 0; i < racket.Length; i++)
                            {
                                // делаем все ракетки правее
                                racket[i].x += 1;
                                // рисуем по символу
                                racket[i].Draw();
                            }
                        }
                        break;
                    // если клавиша стрелка влево
                    case ConsoleKey.LeftArrow:
                        // проверка чтобы игрок не выходил за пределы барьера
                        if (racket[0].x > 0)
                        {
                            // очищаем ракетку
                            Clear();
                            // отрисовываем
                            for (int i = 0; i < racket.Length; i++)
                            {
                                // делаем все ракетки левее
                                racket[i].x -= 1;
                                // рисуем по символу
                                racket[i].Draw();
                            }
                        }
                        break;
                    // если клавиша стрелка вправо
                    case ConsoleKey.RightArrow:
                        // проверка чтобы игрок не выходил за пределы барьера
                        if (racket[racket.Length - 1].x < tennis.Program.widthsize * tennis.Program.multipliersize - 1)
                        {
                            // очищаем ракетку
                            Clear();
                            // отрисовываем
                            for (int i = 0; i < racket.Length; i++)
                            {
                                // делаем все ракетки левее
                                racket[i].x += 1;
                                // рисуем по символу
                                racket[i].Draw();
                            }
                        }
                        break;
                }
            }
        }
    }
    // функция движения для бота
    public void BotMove(char Direction)
    {
        // если направление W(вверх)
        if (Direction == 'W')
        {
            // проверка чтобы бот не выходил за пределы барьера
            if (racket[0].y > 2)
            {
                // очищаем ракетку
                Clear();
                // отрисовываем
                for (int i = 0; i < racket.Length; i++)
                {
                    // делаем все ракетки выше
                    racket[i].y -= 1;
                    // рисуем по символу
                    racket[i].Draw();
                }
            }
        }
        // если направление S(вниз)
        else
        {
            // проверка чтобы бот не выходил за пределы барьера
            if (racket[racket.Length - 1].y < tennis.Program.heightsize * tennis.Program.multipliersize - 3)
            {
                // очищаем ракетку
                Clear();
                // отрисовываем
                for (int i = 0; i < racket.Length; i++)
                {
                    // делаем все ракетки ниже
                    racket[i].y += 1;
                    // рисуем по символу
                    racket[i].Draw();
                }
            }
        }
        // устанавливаем таймер чтобы бот меньше двигался( почему-то таймер в Program не может остановить эту машину)
        Thread.Sleep(tennis.Program.FrameMS);
    }
}

