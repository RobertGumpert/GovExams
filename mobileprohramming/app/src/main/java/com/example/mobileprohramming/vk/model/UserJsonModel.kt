package com.example.mobileprohramming.vk.model

import org.json.JSONObject

data class UserJsonModel(
    val id: Int = 0,
    val firstName: String = "",
    val lastName: String = "",
    val photo: String = "",
    val deactivated: Boolean = false
) {
    companion object {
        fun parse(json: JSONObject) = UserJsonModel(
            id = json.optInt("id", 0),
            firstName = json.optString("first_name", ""),
            lastName = json.optString("last_name", ""),
            photo = json.optString("photo_200", ""),
            deactivated = json.optBoolean("deactivated", false)
        )
    }
}