package com.example.mobileprohramming.view.model

import com.example.mobileprohramming.vk.model.UserJsonModel


data class UserViewModel(
    val id: Int = 0,
    val firstName: String = "",
    val lastName: String = "",
    val photo: String = ""
) {
    companion object {

        fun adapter(jsonDataModel: UserJsonModel) = UserViewModel(
            id = jsonDataModel.id,
            firstName = jsonDataModel.firstName,
            lastName = jsonDataModel.lastName,
            photo = jsonDataModel.photo
        )

    }
}