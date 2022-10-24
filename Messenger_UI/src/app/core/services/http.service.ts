import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';

export class HttpClientService {

    constructor(private httpClient: HttpClient) { }

    post<T>(slug: string, data: any, headers?: HttpHeaders | { [header: string]: string | string[] }) {
        return this.httpClient.post<T>(`${environment.BaseUrl}${slug}`, data, { headers: headers });
    }
    get<T>(slug: string, headers?: HttpHeaders | { [header: string]: string | string[] }) {
        return this.httpClient.get<T>(`${environment.BaseUrl}${slug}`, { headers: headers })
    }
}
