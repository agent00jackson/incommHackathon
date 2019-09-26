package husaynhakeem.io.tictactoe_mvvm.utilities;

class IncommApiClient {
    private static final IncommApiClient ourInstance = new IncommApiClient();

    static IncommApiClient getInstance() {
        return ourInstance;
    }

    //Map all API calls to methods here
    private IncommApiClient() {

    }
}
