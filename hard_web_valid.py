def hard_web_valid(str): # Проверяет, есть ли эта строка в базе
    try:
        token = web_valid(str) # Преобразует строку в токен
        true_token = auth_chain(id) # Берет из базы правильный токен
        if token == true_token:
            return True
        else:
            return False
    except:
        print('ERROR in Hard_Web_Valid')