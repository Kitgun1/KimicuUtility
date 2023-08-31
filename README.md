## Содержание

<details>

  - [Описание проекта](#описание-проекта)
  - [Как добавить в проект](#как-добавить-в-проект)
  - [Примеры](#примеры)
    - [Coroutine](#kicoroutine)
  
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

##  Примеры:
### KiCoroutine
Позволяет очень просто запустить или остановить корутину

Для запуска корутины нужно объявить поле и записать значение, например:
```cs
private readonly KiCoroutine _routine = new KiCoroutine();
```
Запуск корутины - `StartRoutine()` <br>
Остановка корутины - `StartRoutine()`
```cs
// Запуска корутины. forced - принудительная остановка прошлой корутины и запуск текущей:
_routine.StartRoutine(enumerator, forced);

// Остановка существующей корутины, если она есть:
_routine.StopRoutine();
```
Также есть готовые корутины которые можно вызывать из `KiCoroutine`:
---------------------
```csharp
_routine.StartRoutine(KiCoroutine.Delay(2, () => Debug.Log("end")), true);
```
![image](https://github.com/Kitgun1/KimicuUtility/assets/92532054/c76262b6-688e-4510-9f12-19ff7c8841a0)
---------------------
```csharp
_routine.StartRoutine(KiCoroutine.CyclicDelay(5, (t) => Debug.Log($"tick {t}"), () => Debug.Log("end")), true);
```
![image](https://github.com/Kitgun1/KimicuUtility/assets/92532054/1cc96098-0fbb-47f0-98bc-c2bb5214235a)
---------------------
```csharp
_routine.StartRoutine(KiCoroutine.RecurringDelay(1, 5, (t) => Debug.Log($"tick {t}"), () => Debug.Log("end")), true);
```
![image](https://github.com/Kitgun1/KimicuUtility/assets/92532054/0a25e580-70e6-4a50-84c4-9370ba77ae9b)





















