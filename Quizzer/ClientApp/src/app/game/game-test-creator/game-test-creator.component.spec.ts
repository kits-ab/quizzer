import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameTestCreatorComponent } from './game-test-creator.component';

describe('GameTestCreatorComponent', () => {
  let component: GameTestCreatorComponent;
  let fixture: ComponentFixture<GameTestCreatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameTestCreatorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameTestCreatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
