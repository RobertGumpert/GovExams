package com.example.mobileprohramming;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

import com.vk.api.sdk.VK;
import com.vk.api.sdk.auth.VKScope;
import com.vk.api.sdk.utils.VKUtils;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    String[] fingerprints;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        fingerprints = VKUtils.getCertificateFingerprint(this, this.getPackageName());
        Log.i("vk-api-token:", fingerprints[0]);
        VK.login(this, new ArrayList<VKScope>(){
            VKScope.WALL,
            VKScope.PHOTOS
        });
    }
}