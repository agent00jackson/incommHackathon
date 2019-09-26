package ksu.team4.incomm.view;

import android.arch.lifecycle.ViewModelProviders;
import android.databinding.DataBindingUtil;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;

import java.util.ArrayList;

import ksu.team4.incomm.adapters.RecyclerViewAdapter;
import ksu.team4.incomm.viewmodel.MainViewModel;
import ksu.team4.incomm.R;
import ksu.team4.incomm.databinding.ActivityMainBinding;

public class MainActivity extends AppCompatActivity {

    //private static final String GAME_BEGIN_DIALOG_TAG = "game_dialog_tag";
    //private static final String GAME_END_DIALOG_TAG = "game_end_dialog_tag";
    //private static final String NO_WINNER = "No one";
    private MainViewModel mainViewModel;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        ActivityMainBinding binder = DataBindingUtil.setContentView(this, R.layout.activity_main);
        mainViewModel = new MainViewModel(this);
       binder.setMainViewModel(mainViewModel);
//        RecyclerView recyclerView = findViewById(R.id.recycler_view);
//        recyclerView.setLayoutManager(lMan);
//        RecyclerViewAdapter adapter = new RecyclerViewAdapter(this, mImages);
//        recyclerView.setAdapter(adapter);
    }
}
