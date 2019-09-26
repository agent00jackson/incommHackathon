package ksu.io.incomm;

import android.support.test.rule.ActivityTestRule;

import org.junit.Rule;
import org.junit.Test;

import ksu.io.incomm.view.MainActivity;

import static com.schibsted.spain.barista.assertion.BaristaVisibilityAssertions.assertDisplayed;
import static com.schibsted.spain.barista.interaction.BaristaClickInteractions.clickOn;
import static com.schibsted.spain.barista.interaction.BaristaDialogInteractions.clickDialogPositiveButton;
import static com.schibsted.spain.barista.interaction.BaristaEditTextInteractions.writeTo;


public class MainModelActivityShould {

    @Rule
    public ActivityTestRule<MainActivity> activityRule = new ActivityTestRule<>(MainActivity.class);

    private Player player1 = new Player("Husayn", "x");
    private Player player2 = new Player("Yasin", "o");

    @Test
    public void end_game_when_one_player_wins() {
        writeTo(R.id.et_player1, player1.name);
        writeTo(R.id.et_player2, player2.name);
        clickDialogPositiveButton();

        clickOn(R.id.cell_00);
        clickOn(R.id.cell_10);
        clickOn(R.id.cell_01);
        clickOn(R.id.cell_11);
        clickOn(R.id.cell_02);

        assertDisplayed(R.id.tv_winner);
        assertDisplayed(player1.name);
    }
}
