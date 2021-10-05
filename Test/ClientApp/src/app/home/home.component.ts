import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private url: string;
  private http: HttpClient;

  public messages: Message[];
  public errorField: boolean = false;
  public labelInput: string = "form-label";

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + 'home';
    this.http = http;
    this.getMessages();
  }

  getMessages(): void {
    this.http.get<Message[]>(this.url).subscribe(result => {
      this.messages = result;
    }, error => console.error(error));
  }

  encrypt(message: string): void {
    message = message.trim();
    if (!message) {
      this.errorField = true;
      return;
    }
    this.errorField = false;
    this.saveEncrypt({ oldMessage: message } as Message).subscribe(res => {
      console.log(res);
      this.getMessages();
    }, error => console.error(error));
  }

  saveEncrypt(message: Message): Observable<Message> {
    return this.http.post<Message>(this.url, message);
  }

  checkField(): void {
    this.labelInput = "";
  }
}

interface Message {
  id: number;
  oldMessage: string;
  receptTime: string;
  newMessage: string;
}
