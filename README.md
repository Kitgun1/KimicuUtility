# Kimicu Utility

+ [Описание проекта](#описание-проекта)
+ [Связь](#связь)
+ [Поддержать проект](#поддержать-проект)
+ [Как добавить в проект](#как-добавить-в-проект)
+ [Примеры](#примеры)
  + [Корутины](#корутины)
  + [Расширения](#расширения)
    + [Камера](#камера)
    + [CanvasGroup](#canvasgroup)
    + [Вектора](#вектора)
    + [Математика](#математика)
  + [Атрибуты](#атрибуты)
    + [Требовать Interface](#требовать-interface)
    + [Dictionary в Inspector](#сериализовать-dictionary)


---------------------------------------------------------------------------

## Описание проекта:
Этот пакет был разработан специально для упрощения разработки игр на Unity.

---------------------------------------------------------------------------

## Связь:
Если остались вопросы, пиишите в тг -> `@KimicuK`
или пишите [тут](https://github.com/Kitgun1/KimicuUtility/discussions)

---------------------------------------------------------------------------

## Поддержать проект:
Вы можете отправить донат ->
```
https://www.donationalerts.com/r/kimicu
```
<details>

<summary> QR Code </summary>

![image](ResourcesGit~/donation_qrcode.png)

</details>

---------------------------------------------------------------------------

## Как добавить в проект:
В Unity `Window` -> `Package Manager`.
<br>Жмем на `+` и выбрать `Add package by name...` и вставить ссылку:
<br>``` com.unity.nuget.newtonsoft-json ```

Далее заходим в папку проекта > `Packages` > `manifest.json` и добавляем в **"dependencies"**:
```"com.dbrizov.naughtyattributes": "https://github.com/dbrizov/NaughtyAttributes.git#upm"```
![image](https://github.com/Kitgun1/KimicuUtility/assets/92532054/44f9994e-4e9c-4620-9fca-1bdd9d72f38a)

Далее добавляем **KimicuUtility**

Жмем на `+` и выбрать `Add package from git URL...` и вставить ссылку:
<br>``` https://github.com/Kitgun1/KimicuUtility.git ```

Не забудь посмотреть на минимальную требуемую версию Unity в package.json файле.<br> 
Также найдите `Samples` в `package window` и нажмите на кнопку `Import` при необходимости. <br>
Чтобы обновить пакет, просто нажми на кнопку 'Update'.


---------------------------------------------------------------------------

##  Примеры:
### Корутины:
Для запуска корутины нужно объявить поле и записать значение, например:
```cs
private readonly KiCoroutine _routine = new KiCoroutine();
```
Запуск - `_routine.StartRoutine()` <br>
Остановка - `_routine.StartRoutine()`

Готовые корутины в `KiCoroutine`:

```csharp
_routine.StartRoutine(KiCoroutine.Delay(seconds, () => Debug.Log("end")), true);
_routine.StartRoutine(KiCoroutine.CyclicDelay(seconds, (t) => Debug.Log($"tick {t}"), () => Debug.Log("end")), true);
_routine.StartRoutine(KiCoroutine.RecurringDelay(seconds, repetitionsAmount, (t) => Debug.Log($"tick {t}"), () => Debug.Log("end")), true);
```
---------------------------------------------------------------------------

### Расширения:
#### Камера
Установить позицию объекта на точку курсора в мировых координатах
```cs
// Обычный вариант:
component.transform.position = Camera.main.ScreenToWorldPoint(
  new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane));

// С KiUtility:
component.SetWorldSpace(Input.mousePosition, 10);
```

Получить мировую позицию в точке позиции курсора
```cs
// Обычный вариант:
Vector3 vec = Camera.main.ScreenToWorldPoint(
  new Vector3(screenPosition.x, screenPosition.y, Camera.nearClipPlane))

// С KiUtility:
Vector3 vec = Input.mousePosition.GetWorldSpace(10); 
```

Установить позицию объекта на точку курсора в мировых координатах
```cs
// Обычный вариант:
Ray ray = Camera.ScreenToWorldPoint(Input.mousePosition);

// С KiUtility:
Ray ray = Input.mousePosition.GetScreenPointToRay(); 
```

Получить гранцицы камеры с учетом отступов (%)
```cs
Bounds bounds = _camera.GetBoundsPercent(-top, -right, -botton, -left);
```

![image](Resources/Gifs~/example_GetBoundsPercent.gif)


Получить гранцицы камеры с учетом отступов (unit)
```cs
Bounds bounds = _camera.GetBoundsUnit(-top, -right, -botton, -left);
```
![image](Resources/Gifs~/example_GetBoundsUnit.gif)

#### CanvasGroup
Удобное управление CanvasGroup из Editor (ВЫКЛ/ВКЛ) - `KiCanvasGroup`:
![image](Resources/Gifs~/example_KiCanvasGroup.gif)

Узнать состояние CanvasGroup (ВЫКЛ/ВКЛ) - `canvasGroup.IsActive()`:
```cs
// Обычный вариант:
canvasGroup.alpha > 0.6f;

// С KiUtility:
canvasGroup.IsActive();
```

Выключить/Включить отображение canvasGroup - `canvasGroup.Active()`:
```cs
// Обычный вариант:
canvasGroup.alpha = value ? 1 : 0;
canvasGroup.blocksRaycasts = value;
canvasGroup.interactable = value;

// С KiUtility:
canvasGroup.Active(true/false);
// Или для переключения на противоположное состояние:
canvasGroup.Switch()
```

#### Вектора
Конвертировать Vector в VectorBoolean или наоборот - `Vector.ToVector()` или `VectorBoolean2.ToBoolean()`:
```cs
Vector2 vector = Vector.one;

// Обычный вариант:
// to bool
bool vectorBoolX = vector == 0;
bool vectorBoolY = vector == 0; // и тд..
// to vector
if (vectorBoolX) vector.x = 1;
else vector.x = 0; // и тд..

// С KiUtility:
VectorBoolean2 vectorBool = vector.ToBoolean(); // to bool
vector = vectorBool.ToVector(); // to vector
```

#### Математика
Вычислить процент - `(float/double) CalculatePercentage()`:
```cs
(float/double) maxHealth = 136;
(float/double) health = 28;
(float/double) percentage = KiMath.CalculatePercentage(health, maxHealth); // Вывод: 20.5882..%
```

Вычисления оптимальный формат числа - `ValueStringFormat OptimalStringFormat()`:
```cs
float health1 = 36.1234f;
Debug.Log(health1.OptimalStringFormat()); // Вывод: F4
```

Округления числа до указанного количества знаков после запятой - `float OptimalStringFormat()`:
```cs
float health1 = 36.1234f;
float health2 = 36.000012f;
float health3 = 36.01f;

Debug.Log(health1.Round(ValueStringFormat.F2)); // Вывод: 36.12
Debug.Log(health2.Round(ValueStringFormat.F2)); // Вывод: 36
Debug.Log(health3.Round(ValueStringFormat.F6)); // Вывод: 36.01
```

Гибкий рандом - `T[] RandomWithChance<T>()`
```cs
// Определим список с object и их шансом
var objectChanceList = new List<ObjectChance>()
{
  new ObjectChance<type>(object, 25), // выпадает с шансом 25%
  new ObjectChance<type>(object, 20), // выпадает с шансом 20%
  new ObjectChance<type>(object, 50), // выпадает с шансом 50%
  new ObjectChance<type>(object, 100)  // выпадает с шансом 100%
  // Если сумма будет больше 100%, то щансы будут автоматически выровнены.
}
var winObjects = objectChanceList.RandomWithChance<type>(int count = 1);
```

Позиции между 2-мя точками с игнорированием осей - `Vector3.GetVectorBetweenPoints()`
```cs
(Component/Vector3) point1;
(Component/Vector3) point2;

// IgnoreAxis - ось которая будет игнорироваться при вычеслениях.
Vector betweenVector = vector1.GetVectorBetweenPoints(vector2, IgnoreAxis.None);
```

Сумма вектора по модулю - `float.Sum()`
```cs
float speed = Ridigbody.velocity.Sum(); // (10, -10, 5).Sum() = 25
```

---------------------------------------------------------------------------

### Атрибуты:
#### Требовать Interface
```cs
[RequireInterface(typeof(Interface))] private GameObject _example;
```

#### Сериализовать Dictionary
1 вариант - использовать готовые заготовки:
```cs
[SerializeField] private DictionaryFloatVector3 _dictionaryExample11 = new();
[SerializeField] private DictionaryStringInt _dictionaryExample2 = new();
```
![image](https://github.com/Kitgun1/KimicuUtility/assets/92532054/c2dbd4ac-544f-4a7b-90a7-a028a72cef22)

2 вариант - использовать Dictionary со своими типами, которых нет в 1 варианте:<br>
Сначала прописываем где-то вне класса ->
```cs
[Serializable] public class MyDictionaryExample : SerializableDictionary<string, GameObject> { } // Указываем свои типы
#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(MyDictionaryExample))]
public class MyDictionaryExampleDrawer : DictionaryDrawer<string, GameObject> { } // Указываем типы из предыдущего поля
#endif
```
После создания своего варианта можно использовать его как в 1 варианте:
```cs
[SerializeField] private MyDictionaryExample _myDictionaryExample = new();
```
![image](https://github.com/Kitgun1/KimicuUtility/assets/92532054/00f9aa98-9668-4ef4-ae45-47b704e319e9)
