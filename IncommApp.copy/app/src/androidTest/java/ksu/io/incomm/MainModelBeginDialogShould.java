package ksu.io.incomm;

import android.support.test.rule.ActivityTestRule;

import org.junit.Rule;
import org.junit.Test;

import ksu.io.incomm.view.MainActivity;

import static com.schibsted.spain.barista.assertion.BaristaVisibilityAssertions.assertDisplayed;
import static com.schibsted.spain.barista.assertion.BaristaVisibilityAssertions.assertNotExist;
import static com.schibsted.spain.barista.interaction.BaristaDialogInteractions.clickDialogPositiveButton;
import static com.schibsted.spain.barista.interaction.BaristaEditTextInteractions.writeTo;

public class MainModelBeginDialogShould {

    @Rule
    public ActivityTestRule<MainActivity> activityRule = new ActivityTestRule<>(MainActivity.class);

    @Test
    public void display_empty_names_message_if_names_empty() throws Exception {
        writeTo(R.id.et_player1, "");
        writeTo(R.id.et_player2, "");

        clickDialogPositiveButton();

        assertDisplayed(R.string.game_dialog_empty_name);
    }

    @Test
    public void display_same_names_message_if_names_same() throws Exception {
        writeTo(R.id.et_player1, "husaynhakeem");
        writeTo(R.id.et_player2, "husaynhakeem");

        clickDialogPositiveButton();

        assertDisplayed(R.string.game_dialog_same_names);
    }

    @Test
    public void display_empty_name_message_if_one_name_empty() throws Exception {
        writeTo(R.id.et_player1, "");
        writeTo(R.id.et_player2, "husaynhakeem");

        clickDialogPositiveButton();

        assertDisplayed(R.string.game_dialog_empty_name);
    }

    @Test
    public void close_dialog_after_names_valid() throws Exception {
        writeTo(R.id.et_player1, "husaynhakeem 1");
        writeTo(R.id.et_player2, "husaynhakeem 2");

        clickDialogPositiveButton();

        assertNotExist(R.id.layout_player1);
    }
}
