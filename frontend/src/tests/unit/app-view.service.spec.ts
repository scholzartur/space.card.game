import { TestBed, async } from '@angular/core/testing';
import { SpaceHttpService } from 'src/app/services/space-http.service';
import { AppViewService } from 'src/app/services/app-view.service';
import { SpaceHttpServiceMock } from '../utils/space-http.service.mock';
import { PageEvent } from '@angular/material/paginator';
import { AppViewStateDto } from 'src/app/dtos/view/app-view-state.dto';
import { CdkDrag, CdkDragDrop } from '@angular/cdk/drag-drop';

describe('AppViewService', () => {

  let appViewService: AppViewService;
  let appViewState: AppViewStateDto;

  beforeEach(async(() => {
    TestBed.configureTestingModule({

      providers: [
        { provide: SpaceHttpService, useClass: SpaceHttpServiceMock },
        AppViewService
      ],
    });

    appViewService = TestBed.get(AppViewService);
    appViewState = {
      pageSize: 5,
      allStarshipsCount: 0,
      allStarships: [],
      fightingSideOne: [],
      fightingSideTwo: [],
      fightingSideTwoWon: false,
      fightingSideOneWon: false,
      isDraw: false,
    };
  }));

  it('should create the service', () => {
    expect(appViewService).toBeTruthy();
  });

  it('should get starships when page changes', () => {
    const pageEvent = new PageEvent();
    pageEvent.pageSize = 5;
    pageEvent.pageIndex = 1;
    appViewService.getStarshipsOnPageChange(appViewState, pageEvent);
    expect(appViewState.allStarships.length).toBe(3);
  });

  it('should start the battle', () => {
    appViewState.fightingSideOne = [{
      id: 1,
      amountOfPeopleInCrew: 1,
      amountOfWins: 0,
      name: 'starship 1',
      fightingPotential: 1
    }];
    appViewState.fightingSideTwo = [{
      id: 2,
      amountOfPeopleInCrew: 2,
      amountOfWins: 0,
      name: 'starship 2',
      fightingPotential: 2
    }];

    appViewService.startBattle(appViewState);
    expect(appViewState.fightingSideTwoWon).toBe(true);
    expect(appViewState.fightingSideTwo[0].amountOfWins).toBe(1);
  });

  it('should check if dragged UI element is an starship', () => {
    let drag: jasmine.SpyObj<CdkDrag>;
    drag = jasmine.createSpyObj('', ['']);
    drag.element = jasmine.createSpyObj('', ['']);
    drag.element.nativeElement = jasmine.createSpyObj('', ['']);
    drag.element.nativeElement.innerText = 'Starship 1';

    expect(appViewService.isStarship(drag)).toBe(true);

    drag.element.nativeElement.innerText = '  ';

    expect(appViewService.isStarship(drag)).toBe(false);
  });

  it('should get starships via http mock', () => {
    appViewService.getStarships(1, appViewState);

    expect(appViewState.allStarships.length).toBe(3);
    expect(appViewState.allStarshipsCount).toBe(3);
  });

  it('should return swapped object to allStarship list', () => {
    let replaceEvent: jasmine.SpyObj<CdkDragDrop<string[]>>;
    replaceEvent = jasmine.createSpyObj('', ['']);
    replaceEvent.container = jasmine.createSpyObj('', ['']);
    replaceEvent.container.id = 'fightingSideOne';
    appViewState.fightingSideOne[0] = {
      id: 1,
      amountOfPeopleInCrew: 1,
      amountOfWins: 0,
      name: 'starship 1',
      fightingPotential: 1
    };

    appViewService.swapElements(replaceEvent, appViewState);
    expect(appViewState.allStarships.length).toBe(1);
    expect(appViewState.fightingSideOne.length).toBe(0);
  });

});
