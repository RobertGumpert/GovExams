package com.example.mobileprohramming

import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.ListView
import androidx.appcompat.app.AppCompatActivity
import com.example.mobileprohramming.db.ORM
import com.example.mobileprohramming.db.dao.UserDao
import com.example.mobileprohramming.view.UserListView
import com.example.mobileprohramming.view.model.UserViewModel
import com.example.mobileprohramming.vk.model.UserJsonModel
import com.example.mobileprohramming.vk.service.UserService
import com.vk.api.sdk.VK
import com.vk.api.sdk.auth.VKScope

class MainActivity : AppCompatActivity() {
    // fingerPrints = VKUtils.getCertificateFingerprint(this, this.packageName)
    // Log.i("vk-api-token", fingerPrints?.get(0))
    // VK.login(this, arrayListOf(VKScope.WALL, VKScope.PHOTOS))
    // var fingerPrints: Array<String?>? = null


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        VK.login(this, arrayListOf(VKScope.WALL, VKScope.PHOTOS))
        setContentView(R.layout.main_view)
        var dbList = listOf<UserJsonModel>()
        val orm = UserDao()
        val requestButton = findViewById<Button>(R.id.buttonLoad)
        requestButton.setOnClickListener {
            val requestService = UserService()
            requestService.myFriends { list: List<UserJsonModel> ->
                run {
                    dbList = list
                    val viewModelList = mutableListOf<UserViewModel>()
                    for (element in list) {
                        viewModelList.add(
                            UserViewModel.adapter(
                                element
                            )
                        )
                    }
                    val listView = findViewById<ListView>(R.id.listView)
                    listView.adapter = UserListView(this, viewModelList)
                }
            }
        }
        val buttonSave = findViewById<Button>(R.id.buttonSave)
        buttonSave.setOnClickListener {
            orm.addListUsers(dbList, this)
        }

        val buttonLoad = findViewById<Button>(R.id.buttonLoad)
        buttonLoad.setOnClickListener {
            dbList = orm.getListUsers(this)
        }
    }


//
//    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
//        val callback = object: VKAuthCallback {
//            override fun onLogin(token: VKAccessToken) {
//                UserActivity.startFrom(this@MainActivity)
//                finish()
//            }
//            override fun onLoginFailed(errorCode: Int) {}
//        }
//        if (data == null || !VK.onActivityResult(requestCode, resultCode, data, callback)) {
//            super.onActivityResult(requestCode, resultCode, data)
//        }
//    }
//
//    companion object {
//        fun startFrom(context: Context) {
//            val intent = Intent(context, MainActivity::class.java)
//            intent.flags = Intent.FLAG_ACTIVITY_NEW_TASK or Intent.FLAG_ACTIVITY_CLEAR_TOP
//            context.startActivity(intent)
//        }
//    }
}