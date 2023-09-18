
|      Languages      |
|:-------------------:|
| [Russian](#русский) |
| [English](#english) |

# Русский:
+ Текст
  + Текст
    + Текст


# English:



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

Далее заходим в папку проекта > Packages > manifest.json и добавляем в **"dependencies"**:
```"com.dbrizov.naughtyattributes": "https://github.com/dbrizov/NaughtyAttributes.git#upm"```
![image](https://github.com/Kitgun1/KimicuUtility/assets/92532054/44f9994e-4e9c-4620-9fca-1bdd9d72f38a)

### Далее добавляем [KimicuUtility](#далее-добавляем-kimicuutility)

Жмем на '+' и выбрать 'Add package from git URL...' и вставить ссылку:
<br>``` https://github.com/Kitgun1/KimicuUtility.git ```

Не забудь посмотреть на минимальную требуемую версию Unity в package.json файле.

Также найдите 'Samples' в package window и нажмите на кнопку 'Import' при необходимости.

Чтобы обновить пакет, просто нажми на кнопку 'Update'.

---------------------------------------------------------------------------

##  Примеры:
### KiCoroutine
Для запуска корутины нужно объявить поле и записать значение, например:
```cs
private readonly KiCoroutine _routine = new KiCoroutine();
```
Запуск - `StartRoutine()` <br>
Остановка - `StartRoutine()`
```cs
// Запуска корутины. forced - принудительная остановка прошлой корутины и запуск текущей:
_routine.StartRoutine(enumerator, forced);

// Остановка существующей корутины, если она есть:
_routine.StopRoutine();
```
Готовые корутины в `KiCoroutine`:
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

---------------------------------------------------------------------------

## Extensions:
### Camera
Методы:
```cs
void SetWorldSpace<T>(this T component, Vector2 screenPosition, float z = -1)
Vector3 GetWorldSpace(this Vector3 screenPosition)
Ray GetScreenPointToRay(this Vector3 screenPosition)
```
---------------------
Примеры:

Установить позицию объекта на точку курсора в мировых координатах
```cs
// Обычный вариант:
component.transform.position = Camera.main.ScreenToWorldPoint(
  new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane));

// С KiUtility:
component.SetWorldSpace(Input.mousePosition, 10);
```

Получить мирувую позицию в точке позиции курсора
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

### CanvasGroup
Методы:
```cs
bool IsActive(this CanvasGroup canvasGroup)
void Active(this CanvasGroup canvasGroup, bool value)
void Switch(this CanvasGroup canvasGroup)
```
---------------------
Примеры:

Узнать состояние CanvasGroup (ВЫКЛ/ВКЛ) - `canvasGroup.IsActive()`:
```cs
// Обычный вариант:
canvasGroup.alpha > 0.6f

// С KiUtility:
canvasGroup.IsActive()
```

Выключить/Включить отображение canvasGroup - `canvasGroup.Active()`:
```cs
// Обычный вариант:
canvasGroup.alpha = value ? 1 : 0;
canvasGroup.blocksRaycasts = value;
canvasGroup.interactable = value;

// С KiUtility:
canvasGroup.Active(true/false);
// Если нужно переключить на противоположный вариант, можно использовать:
canvasGroup.Switch()
```

### Vector
Методы:
```cs
Vector(2/3/4) ToVector(this VectorBoolean(2/3/4) vectorBoolean)
VectorBoolean(2/3/4) ToBoolean(this Vector(2/3/4) vector)
```
---------------------
Примеры:

Конвертировать Vector в VectorBoolean или наооборот - `Vector.ToVector()` или `VectorBoolean2.ToBoolean()`:
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

### Математика
Примеры:

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

Debug.Log(health1.Crop(ValueStringFormat.F2)); // Вывод: 36.12
Debug.Log(health2.Crop(ValueStringFormat.F2)); // Вывод: 36
Debug.Log(health3.Crop(ValueStringFormat.F6)); // Вывод: 36.01
```

Гибкий рандом - `T[] RandomWithChance<T>()`
```cs
var objectChanceList = new List<ObjectChance>()
{
  new ObjectChance {Object = T, 25}, // выпадает с шансом 25%
  new ObjectChance {Object = T, 20}, // выпадает с шансом 20%
  new ObjectChance {Object = T, 50}, // выпадает с шансом 50%
  new ObjectChance {Object = T, 30}  // выпадает с шансом 30%
}
T[] winObjects = objectChanceList.RandomWithChance<T>(int count = 1);
```

Позиции между 2-мя точками с игнорированием осей - `Vector3.GetVectorBetweenPoints()`
```cs
(Component/Vector3) point1;
(Component/Vector3) point2;

// IgnoreAxis - ось которая будет игнорироваться при вычеслениях.
Vector betweenVector = vector1.GetVectorBetweenPoints(vector2, IgnoreAxis.None);
```

Сумма векторов - `float.Sum()`
```cs
float speed = Ridigbody.velocity.Sum(); // (10, -10, 5).Sum() = 25
```

---------------------------------------------------------------------------

## Attribute:
### Require Interface
```cs
[RequireInterface(typeof(Interface))] private GameObject _example;
```


### Serialization Dictionary
1 вариант - использовать готовые заготовки:
```cs
[SerializeField] private DictionaryFloatVector3 _dictionaryExample11 = new();
[SerializeField] private DictionaryStringInt _dictionaryExample2 = new();
```
![image](https://github.com/Kitgun1/KimicuUtility/assets/92532054/c2dbd4ac-544f-4a7b-90a7-a028a72cef22)

2 вариант - использовать Dictionary со своими типами, которых нет в 1 варианте:
Сначала пропысываем где-то вне класса ->
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
















