package com.example.mobileprohramming.vk.request

import com.example.mobileprohramming.vk.model.UserJsonModel
import com.vk.api.sdk.requests.VKRequest
import org.json.JSONObject

class UserRequest(method: String) : VKRequest<List<UserJsonModel>>(method) {
    override fun parse(responseJsonObject: JSONObject): List<UserJsonModel> {
        val jsonArray = responseJsonObject
            .getJSONObject("response")
            .getJSONArray("items")
        val jsonDataModels = ArrayList<UserJsonModel>()
        for (next in 0 until jsonArray.length()) {
            jsonDataModels.add(
                UserJsonModel.parse(
                    jsonArray.getJSONObject(next)
                )
            )
        }
        return jsonDataModels
    }
}