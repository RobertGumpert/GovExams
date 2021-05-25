package com.example.mobileprohramming.db

import android.content.Context
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper

class ORM(context: Context) : SQLiteOpenHelper(context, "user.db", null, 1) {

    override fun onCreate(db: SQLiteDatabase?) {
        db?.execSQL(
            "CREATE TABLE IF NOT EXISTS Users(" +
                        "id integer primary key autoincrement, " +
                        "firstName text, " +
                        "lastName text, " +
                        "photo text" +
                 ");"
        )
    }

    override fun onUpgrade(db: SQLiteDatabase?, oldVersion: Int, newVersion: Int) {
        onCreate(db)
    }

    companion object {
        private var instance: ORM? = null
        fun getInstance(context: Context? = null): ORM {
            if (instance == null) {
                instance = ORM(context!!)
            }
            return instance!!
        }
    }
}