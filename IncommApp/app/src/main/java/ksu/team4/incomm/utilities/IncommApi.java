package ksu.team4.incomm.utilities;

import android.util.Log;
import android.widget.Toast;

import java.io.IOException;
import java.util.List;

import ksu.team4.incomm.DataRecords.Account;
import ksu.team4.incomm.DataRecords.AccountsResponse;

import okhttp3.Interceptor;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class IncommApi {
    private Retrofit retroClient;
    private IncommApiInterface incommClient;

    public IncommApi()
    {
        OkHttpClient.Builder httpClient = new OkHttpClient.Builder();
        httpClient.addInterceptor(new Interceptor() {
            @Override
            public Response intercept(Interceptor.Chain chain) throws IOException {
                Request original = chain.request();

                Request request = original.newBuilder()
                        .header("X-API-Key", "ufBsC0wSbhTkLrB2jUdL")
                        .method(original.method(), original.body())
                        .build();

                return chain.proceed(request);
            }
        });

        retroClient = new Retrofit.Builder()
                .baseUrl("https://us-central1-incomm-hackathon-api.cloudfunctions.net/api")
                .client(httpClient.build())
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        incommClient = retroClient.create(IncommApiInterface.class);
    }

    public List<Account> getAccounts()
    {
        Call<AccountsResponse> call = incommClient.getAccounts();

        AccountsResponse response = null;

        try
        {
            response = call.execute().body();
        }
        catch(IOException e)
        {
            Log.d("IncommApi", "getAccounts: IOException: " + e.getMessage());
        }

        if(response == null)
            throw new NullPointerException("Response empty");

        return response.mAccounts;
    }
}
