package com.example.mobileprohramming.view

import android.annotation.SuppressLint
import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import android.widget.TextView
import com.example.mobileprohramming.R
import com.example.mobileprohramming.view.model.UserViewModel

// val imageView: ImageView = view.findViewById(R.id.list_row_icon) as ImageView
class UserListView(context: Context, private val viewModel: List<UserViewModel>): BaseAdapter() {

    private var layout: LayoutInflater = LayoutInflater.from(context)

    @SuppressLint("InflateParams")
    override fun getView(position: Int, view: View?, parent: ViewGroup?): View {
        var view = view
        if (view == null) {
            view = layout.inflate(R.layout.users_list_view, null)!!
        }
        val item = viewModel[position]
        val textView = view.findViewById<View>(R.id.list_row_text) as TextView
        textView.text = "${item.firstName} ${item.lastName}"
        return view
    }

    override fun getItem(position: Int): Any {
        return viewModel[position]
    }

    override fun getItemId(position: Int): Long {
        return position.toLong()
    }

    override fun getCount(): Int {
        return viewModel.size
    }

}