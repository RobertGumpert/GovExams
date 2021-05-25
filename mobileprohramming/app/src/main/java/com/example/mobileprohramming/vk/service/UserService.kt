package com.example.mobileprohramming.vk.service

import com.example.mobileprohramming.vk.model.UserJsonModel
import com.example.mobileprohramming.vk.request.UserRequest


class UserService {

    private val MethodGetFriends = "friends.get"
    private val executor: RequestExecutorService = RequestExecutorService.getInstance()

    fun userFriends(
        id: Int,
        onSuccess: (users: List<UserJsonModel>) -> Unit
    ) {
        downloadUserFriends(onSuccess, id)
    }

    fun myFriends(
        onSuccess: (users: List<UserJsonModel>) -> Unit
    ) {
        downloadUserFriends(onSuccess)
    }

    private fun downloadUserFriends(
        onSuccess: (users: List<UserJsonModel>) -> Unit,
        id: Int? = null
    ) {
        val requestConstructor = UserRequest(MethodGetFriends)
        if (id != null) {
            requestConstructor.addParam("user_id", id)
        }
        requestConstructor.addParam("fields", "photo_200")
        executor.doRequest(
            requestConstructor,
            onSuccess
        )
    }
}