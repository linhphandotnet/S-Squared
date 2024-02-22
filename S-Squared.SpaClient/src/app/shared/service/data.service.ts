import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  constructor(private httpClient: HttpClient) { }

  getData(url: string, paras?: any): Observable<any> {
    return this.httpClient.get(url)
      .pipe(tap((res: any) => {
        return res;
      }), catchError(this.handleError));
  }

  postData(url: string, data: any): Observable<boolean> {
    return this.httpClient.post(url, data)
      .pipe(tap((res: any) => {
        return res;
      }), catchError(this.handleError));
  }

  putData(url: string, data: any): Observable<boolean> {
    return this.httpClient.put(url, data)
      .pipe(tap((res: any) => {
        return res;
      }), catchError(this.handleError));
  }

  deleteData(url: string): Observable<boolean> {
    return this.httpClient.delete(url)
      .pipe(tap((res: any) => {
        return res;
      }), catchError(this.handleError));
  }

  private handleError(error: any) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('Client side network error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error('Backend - ' +
        `status: ${error.status}, ` +
        `statusText: ${error.statusText}, ` +
        `message: ${error.message}`);
    }

    //this.errorData = {
    //  description: error.message,
    //  text: error.statusText,
    //  type: error.status,
    //  title: error.status + 'Error Page'
    //}

    // return an observable with a user-facing error message
    return throwError(error || 'server error');
  }

}
