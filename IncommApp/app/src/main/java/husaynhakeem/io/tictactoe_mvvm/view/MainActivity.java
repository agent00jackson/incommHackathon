package husaynhakeem.io.tictactoe_mvvm.view;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;

import husaynhakeem.io.tictactoe_mvvm.viewmodel.MainViewModel;

public class MainActivity extends AppCompatActivity {

    private static final String GAME_BEGIN_DIALOG_TAG = "game_dialog_tag";
    private static final String GAME_END_DIALOG_TAG = "game_end_dialog_tag";
    private static final String NO_WINNER = "No one";
    private MainViewModel mainViewModel;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }
}
