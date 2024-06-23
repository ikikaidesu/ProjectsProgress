using System;

// класс отвечающий за пиксели в консоли
public class Pixel
{
	// координаты
	public int x;
	public int y;
	// символ который будет отрисовываться
	public char pixel;
	// цвет
	public ConsoleColor color;

	// создание и отрисовка пикселя
	// стартовая координата X
	// стартовая координата Y
	// Символ которым будет выглядеть пиксель
	// цвет пикселя
	public Pixel(int X, int Y, char Pixel, ConsoleColor Color)
    {
		x = X;
		y = Y;
		pixel = Pixel;
		color = Color;
		Draw();
    }
	// функция отрисовки пикселя
	public void Draw()
	{
		// ставим цвет
		Console.ForegroundColor = color;
		// перемещаем курсор для отрисовки
		Console.SetCursorPosition(x, y);
		// рисуем
		Console.Write(pixel);
	}
	// функция очистки пикселя
	public void Clear()
    {
		// перемещаем курсор для очистки
		Console.SetCursorPosition(x, y);
		// очищаем
		Console.Write(' ');
    }
}
