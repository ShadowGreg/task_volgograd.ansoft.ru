Я создал базу данных FireBird и микросервис. 
В базе данных я создал две обязательные таблицы с обязательными полями. 
Первая таблица называется 'Сообщения для отправки'
 и содержит поля: guid сообщения, e-mail, номер телефона, тип отправки сообщения, тема, содержание и результат отправки.

Вторая таблица называется 'Приложения' и содержит поле для файла, предназначенного для отправки на e-mail. 

Мой микросервис предоставляет следующий функционал:


Получение сообщения для отправки с фиксацией в создаваемой базе данных и отправкой в ответе GUID сообщения. GUID является необязательным входным параметром. Если GUID не указан в запросе на отправку сообщения, микросервис автоматически генерирует новый GUID.
При попытке повторной отправки сообщения с уже зарегистрированным GUID в базе данных, микросервис обновляет соответствующее сообщение. Обновление возможно только в случае, если сообщение еще не было отправлено. В противном случае, микросервис возвращает ошибку.
Микросервис также осуществляет отправку сообщений заданное количество раз с заданным периодом ожидания между отправками. Результаты отправки сообщений фиксируются в базе данных.

Мой микросервис имеет следующие эндпоинты:

http://xxx.xxx.xxx/msg - для отправки сообщения (метод POST)
http://xxx.xxx.xxx/msg/{guid} - для получения результатов отправки сообщения (метод GET)
http://xxx.xxx.xxx/info - для получения информации о сервисе (метод GET)

Микросервис также предоставляет API для выполнения всех поставленных задач.




Для реализации функционала получения и обновления сообщений в базе данных Firebird, 
потребуются две хранимые процедуры. Ниже приведены примеры кода для этих процедур:


Хранимая процедура для получения сообщения с фиксацией в базе данных и отправкой GUID сообщения в ответ:


Explain
CREATE PROCEDURE GetAndInsertMessage (
  IN pGUID VARCHAR(36) = NULL -- входной параметр GUID, по умолчанию NULL
)
AS
BEGIN
  DECLARE vGUID VARCHAR(36); -- переменная для хранения сгенерированного GUID
  
  IF (pGUID IS NULL) THEN
    -- Генерация нового GUID, если параметр не указан
    vGUID = GEN_UUID();
  ELSE
    vGUID = pGUID;
  END IF;

  -- Вставка сообщения в базу данных
  INSERT INTO Messages (GUID, Email, PhoneNumber, MessageType, Subject, Content, SendResult)
  VALUES (vGUID, 'example@example.com', '123456789', 'Type', 'Subject', 'Content', 'Pending');

  -- Возврат GUID сообщения в ответ
  SELECT vGUID AS MessageGUID FROM RDB$DATABASE INTO :MessageGUID;
END

Хранимая процедура для обновления сообщения в базе данных, при условии, что сообщение еще не было отправлено:


Explain
CREATE PROCEDURE UpdateMessage (
  IN pGUID VARCHAR(36),
  IN pEmail VARCHAR(255),
  IN pPhoneNumber VARCHAR(20),
  IN pMessageType VARCHAR(100),
  IN pSubject VARCHAR(255),
  IN pContent BLOB SUB_TYPE 1,
  IN pSendResult VARCHAR(100)
)
AS
BEGIN
  UPDATE Messages
  SET Email = pEmail, PhoneNumber = pPhoneNumber, MessageType = pMessageType,
      Subject = pSubject, Content = pContent, SendResult = pSendResult
  WHERE GUID = pGUID AND SendResult = 'Pending';
END