# Kimicu Utility
## Описание:
Этот пакет был разработан специально для упрощения разработки игр на Unity.
## Как добавить в проект:
В Unity открыть 'Window' -> 'Package Manager'.
### Добавляем зависимости:
Жмем на '+' и выбрать 'Add package by name...' и вставить ссылку: 
```
com.unity.nuget.newtonsoft-json
```
<br> Жмем на '+' и выбрать 'Add package from git URL...' и вставить эти дополнительные ссылки: 
```
https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask
```
```
https://github.com/forcepusher/com.agava.yandexmetrica.git
```
```
https://github.com/forcepusher/com.agava.webutility.git
```
```
https://github.com/forcepusher/com.agava.yandexgames.git
```
Также нужно добавить [NaughtyAttribute](https://github.com/dbrizov/NaughtyAttributes)
### Тепрь добавляем наш пакет
Жмем на '+' и выбрать 'Add package from git URL...' и вставить эти дополнительные ссылки: 
```
https://github.com/Kitgun1/KimicuUtility.git
```
Не забудь посмотреть на минимальную требуемую версию Unity в package.json файле.

Также найдите 'Samples' в package window и нажмите на кнопку 'Import' у 'Resources' и у других при необходимости.

Чтобы обновить пакет, просто нажми на кнопку 'Update'.

