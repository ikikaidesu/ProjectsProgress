from tkinter import *  # библиотека для граф. интерфейса
import random

def game(): # стартовое окно
    def again():
        global windowgame
        windowgame.destroy()
        game()
    def checkvalue():
        global initialpromt
        if FromEntry.get().isdigit() and ToEntry.get().isdigit():
            if int(FromEntry.get()) < int(ToEntry.get()):
                gotogame()
            else:
                initialpromt.destroy()
                initialpromt = Label(window, text="Введены неверные данные.")
                initialpromt.place(x=120, y=130)
        else:
            initialpromt.destroy()
            initialpromt = Label(window, text="Введены неверные данные.")
            initialpromt.place(x=120, y=130)
    def gotogame(): # игровое окно
        global promt, btn
        def checkgamevalue(): # проверка чисел
            global promt, btn
            if EntryValue.get().isdigit() == False:
                promt.destroy()
                promt = Label(windowgame, text="Введены неверные данные") # подсказка если число меньше
                promt.place(x=130, y=70)
            if int(EntryValue.get()) > HiddenValue:
                promt.destroy()
                promt = Label(windowgame, text="Мое число меньше.") # подсказка если число меньше
                promt.place(x=150, y=70)
            if int(EntryValue.get()) < HiddenValue:
                promt.destroy()
                promt = Label(windowgame, text="Мое число больше.") # подсказка если число больше
                promt.place(x=150, y=70)
            if int(EntryValue.get()) == HiddenValue:
                promt.destroy()
                promt = Label(windowgame, text="Ты угадал!") # победа
                promt.place(x=150, y=70)
                btn.destroy()
                btn = Button(windowgame, text="Заново?", command=again)
                btn.place(x=240, y=45)
        global windowgame, btn
        fe, te = FromEntry.get(), ToEntry.get()
        window.destroy() # закрываем старое
        # настройка самого окна
        windowgame = Tk()  # создание окна
        windowgame.title("больше/меньше")  # титульное название программы
        windowgame.geometry('420x150+450+350')  # размеры окна
        windowgame.iconbitmap('icon.ico') # иконка
        windowgame.resizable(width=False, height=False)  # запрет на изменение разрешения окна

        AboutRange = Label(windowgame, text="диапазон от {0} до {1}.".format(fe, te), font=("Arial Bold", 15)).place(x=105, y=10)
        # надпись с диапазоном
        HiddenValue = random.randint(int(fe), int(te)) # загаданное число
        EntryValue = Entry(windowgame, width=20) # ввод чисел
        EntryValue.place(x=110, y=50)
        btn = Button(windowgame, text="Загадать!", command=checkgamevalue)
        btn.place(x=240, y=45)
        promt = Label(windowgame, text="") # кнопка для принятия
        promt.place(x=150, y=70)
        window.mainloop() # поле для подсказок

    # настройка самого окна
    global window, initialpromt
    window = Tk()  # создание окна
    window.title("больше/меньше")  # титульное название программы
    window.geometry('420x150+450+350')  # размеры окна
    window.iconbitmap('icon.ico')  # иконка
    window.resizable(width=False, height=False) # запрет на изменение разрешения окна

    # правила игры
    aboutgame = Label(window, text="Добро пожаловать в игру 'больше/меньше'.", font=("Arial Bold", 15))
    aboutgame.grid(row=0)
    aboutgame1 = Label(window, text="Твоя задача угадать какое число я загадал!", font=("Arial Bold", 15))
    aboutgame1.grid(row=1)
    aboutgame2 = Label(window, text="укажите диапазон загадывания числа.", font=("Arial Bold", 15))
    aboutgame2.grid(row=2)

    # ввод диапазона для загадывания числа
    From = Label(window, text='от', font=("Arial Bold", 10)).place(x=90, y=110)
    FromEntry = Entry(window, width=10)
    FromEntry.place(x=110, y=110)
    To = Label(window, text="до", font=("Arial Bold", 10)).place(x=180, y=110)
    ToEntry = Entry(window, width=10)
    ToEntry.place(x=200, y=110)
    btn = Button(window, text="Загадать!", command=checkvalue).place(x=270, y=106)
    #расстановка координатами так как 'стандарт' колонны 0 уже занят поэтому любой другой объект при попадании в колонну 0 будет по середине относительно большого текста
    initialpromt = Label(window, text="")
    initialpromt.place(x=80, y = 130)

    window.mainloop()  # открытие окна

if __name__ == "__main__":
    game() # запуск самой программы
