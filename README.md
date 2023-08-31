## Содержание

<details>

  - [Описание проекта](#описание-проекта)
  - [Как добавить в проект](#как-добавить-в-проект)
  - [Примеры](#примеры)
    - [Примеры 2](#пример1)
  
</details>

---------------------------------------------------------------------------

## Описание проекта:
Этот пакет был разработан специально для упрощения разработки игр на Unity.

---------------------------------------------------------------------------

## Как добавить в проект:
В Unity открыть 'Window' -> 'Package Manager'.

Жмем на '+' и выбрать 'Add package by name...' и вставить ссылку: 
<br>``` com.unity.nuget.newtonsoft-json ```

Жмем на '+' и выбрать 'Add package from git URL...' и вставить эти дополнительные ссылки: 
<br>``` https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask ```
<br>``` https://github.com/forcepusher/com.agava.yandexmetrica.git ```
<br>``` https://github.com/forcepusher/com.agava.webutility.git ```
<br>``` https://github.com/forcepusher/com.agava.yandexgames.git ```

Также нужно добавить [NaughtyAttribute](https://github.com/dbrizov/NaughtyAttributes). Скачиваем архив и закидываем в проект.

### Далее добавляем [KimicuUtility](#далее-добавляем-kimicuutility)

Жмем на '+' и выбрать 'Add package from git URL...' и вставить ссылку: 
<br>``` https://github.com/Kitgun1/KimicuUtility.git ```

Не забудь посмотреть на минимальную требуемую версию Unity в package.json файле.

Также найдите 'Samples' в package window и нажмите на кнопку 'Import' при необходимости.

Чтобы обновить пакет, просто нажми на кнопку 'Update'.

---------------------------------------------------------------------------

#  Примеры:
## Пример1:
