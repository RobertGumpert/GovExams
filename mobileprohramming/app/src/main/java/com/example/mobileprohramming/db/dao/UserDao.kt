package com.example.mobileprohramming.db.dao

import android.content.Context
import com.example.mobileprohramming.db.ORM
import com.example.mobileprohramming.vk.model.UserJsonModel

class UserDao {

    fun addListUsers(list: List<UserJsonModel>, context: Context) {
        val orm = ORM.getInstance(context)
        val db = orm.writableDatabase
        list.forEach {
            val values = ContentValues().apply {
                put("firstName", it.firstName)
                put("lastName", it.lastName)
                put("photo", it.photo)
            }
            val newRowId = db?.insert("Users", null, values)
        }
    }

    fun getListUsers(context: Context): List<UserJsonModel> {
        val orm = ORM.getInstance(context)
        val db = orm.writableDatabase
        val list = mutableListOf<UserJsonModel>()
        val cursor = db.query("Users", null, null, null, null, null, null)
        while (cursor?.moveToNext()!!) {
            val id = cursor.getInt(0)
            val firstName = cursor.getString(1)
            val lastName = cursor.getString(2)
            val photo = cursor.getString(3)
            val user = UserJsonModel(id, firstName, lastName, photo)
            list.add(user)
        }
        return list
    }
}