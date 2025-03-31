CREATE TABLE IF NOT EXISTS "User" (
                                      id SERIAL PRIMARY KEY,
                                      username TEXT NOT NULL UNIQUE,
                                      password TEXT NOT NULL,
                                      lastLogin TIMESTAMP,
                                      dateOfBirth DATE
);

CREATE TABLE IF NOT EXISTS "Card" (
                                      id SERIAL PRIMARY KEY,
                                      cardNumber TEXT NOT NULL,
                                      description TEXT,
                                      expirationDate DATE,
                                      amount NUMERIC(12,2) DEFAULT 0,
    userId INTEGER NOT NULL REFERENCES "User"(id) ON DELETE CASCADE
    );

CREATE TABLE IF NOT EXISTS "Transaction" (
                                             id SERIAL PRIMARY KEY,
                                             date TIMESTAMP NOT NULL,
                                             description TEXT,
                                             type TEXT CHECK (type IN ('income', 'expense')),
    amount NUMERIC(12,2) NOT NULL,
    cardId INTEGER NOT NULL REFERENCES "Card"(id) ON DELETE CASCADE
    );
