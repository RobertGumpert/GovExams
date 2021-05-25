package com.example.mobileprohramming.vk.service

import android.util.Log
import com.vk.api.sdk.VK
import com.vk.api.sdk.VKApiCallback
import com.vk.api.sdk.requests.VKRequest

class RequestExecutorService {

    fun <T> doRequest(request: VKRequest<T>, onSuccess: (result: T) -> Unit) {
        VK.execute(request, object : VKApiCallback<T> {
            override fun fail(error: Exception) {
                Log.e(TAG + "[fail(error: Exception)]", error.toString())
            }
            override fun success(result: T) {
                onSuccess(result)
            }
        })
    }

    companion object {
        private var instance: RequestExecutorService? = null
        const val TAG: String = "API"
        fun getInstance(): RequestExecutorService {
            if (instance == null) {
                instance = RequestExecutorService()
            }
            return instance!!
        }
    }

}