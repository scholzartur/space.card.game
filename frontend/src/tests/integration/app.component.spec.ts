import { TestBed, async } from '@angular/core/testing';
import { AppComponent } from 'src/app/app.component';
import { DemoMaterialModule } from 'src/app/material-module';
import { MatDialog } from '@angular/material/dialog';
import { AppViewService } from 'src/app/services/app-view.service';
import { SpaceHttpService } from 'src/app/services/space-http.service';
import { SpaceHttpServiceMock } from '../utils/space-http.service.mock';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { AppRoutingModule } from 'src/app/app-routing.module';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        MatNativeDateModule,
        ReactiveFormsModule,
        AppRoutingModule,
        DemoMaterialModule,
      ],
      declarations: [
        AppComponent
      ],
      providers: [
        AppViewService,
        { provide: SpaceHttpService, useClass: SpaceHttpServiceMock },
        MatDialog, // for some reason this control does not render well in tests
        { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' } },
      ]
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it('should render the title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('#tittle').textContent).toContain('WECLOME TO SPACE CARD GAME');
  });

  it('should render starships list', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('#starships')).toBeTruthy();
  });

  it('should render battle slot two', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('#fightingSideTwo')).toBeTruthy();
  });

  it('should render battle slot one', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('#fightingSideOne')).toBeTruthy();
  });

  it('should render fight button', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('.fight-btn')).toBeTruthy();
  });
});
