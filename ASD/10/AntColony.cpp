#include <iostream>
#include <vector>
#include <cmath>
#include <cstdlib>
#include <ctime>
#include <limits>

// Количество городов
const int NUM_CITIES = 5;

// Количество муравьев
const int NUM_ANTS = 10;

// Количество итераций
const int NUM_ITERATIONS = 100;

// Феромоны на ребрах
double pheromones[NUM_CITIES][NUM_CITIES];

// Расстояния между городами
double distances[NUM_CITIES][NUM_CITIES] = {
	{0, 10, 15, 20, 25},
	{10, 0, 35, 25, 30},
	{15, 35, 0, 30, 20},
	{20, 25, 30, 0, 10},
	{25, 30, 20, 10, 0}
};

// Вероятность перехода из города i в город j
double transitionProbabilities[NUM_CITIES][NUM_CITIES];

// Инициализация феромонов
void initPheromones() {
	for (int i = 0; i < NUM_CITIES; ++i) {
		for (int j = 0; j < NUM_CITIES; ++j) {
			if (i != j) {
				pheromones[i][j] = 1.0;
			}
			else {
				pheromones[i][j] = 0.0;
			}
		}
	}
}

// Рассчитать вероятности перехода из города i в город j
void calculateProbabilities() {
	double total = 0.0;

	for (int i = 0; i < NUM_CITIES; ++i) {
		for (int j = 0; j < NUM_CITIES; ++j) {
			if (i != j) {
				transitionProbabilities[i][j] = pow(pheromones[i][j], 1.0) * pow(1.0 / distances[i][j], 2.0);
				total += transitionProbabilities[i][j];
			}
			else {
				transitionProbabilities[i][j] = 0.0;
			}
		}
	}

	// Нормализация вероятностей
	for (int i = 0; i < NUM_CITIES; ++i) {
		for (int j = 0; j < NUM_CITIES; ++j) {
			if (i != j) {
				transitionProbabilities[i][j] /= total;
			}
		}
	}
}

// Выбор следующего города для муравья
int selectNextCity(int ant, std::vector<bool>& visited) {
	int currentCity = -1;
	double r = static_cast<double>(rand()) / RAND_MAX;
	double sum = 0.0;

	for (int i = 0; i < NUM_CITIES; ++i) {
		if (!visited[i]) {
			sum += transitionProbabilities[currentCity == -1 ? ant : currentCity][i];
			if (sum >= r) {
				currentCity = i;
			}
		}
	}

	return currentCity;
}

// Обновление феромонов на пути
void updatePheromones(std::vector<std::vector<int>>& antsPaths) {
	double evaporationRate = 0.5;

	for (int i = 0; i < NUM_CITIES; ++i) {
		for (int j = 0; j < NUM_CITIES; ++j) {
			if (i != j) {
				pheromones[i][j] *= (1 - evaporationRate);
			}
		}
	}

	for (int i = 0; i < NUM_ANTS; ++i) {
		double antPheromone = 1.0;
		for (int j = 0; j < NUM_CITIES - 1; ++j) {
			int cityA = antsPaths[i][j];
			int cityB = antsPaths[i][j + 1];
			antPheromone += 100.0 / distances[cityA][cityB];
		}
		int firstCity = antsPaths[i][0];
		int lastCity = antsPaths[i][NUM_CITIES - 1];
		antPheromone += 100.0 / distances[lastCity][firstCity];

		for (int j = 0; j < NUM_CITIES - 1; ++j) {
			int cityA = antsPaths[i][j];
			int cityB = antsPaths[i][j + 1];
			pheromones[cityA][cityB] += antPheromone;
			pheromones[cityB][cityA] += antPheromone;
		}
		pheromones[lastCity][firstCity] += antPheromone;
		pheromones[firstCity][lastCity] += antPheromone;
	}
}

// Решение задачи коммивояжера с помощью муравьиного алгоритма
void solveTSP() {
	std::vector<std::vector<int>> antsPaths(NUM_ANTS, std::vector<int>(NUM_CITIES));
	std::vector<bool> visited(NUM_CITIES, false);

	initPheromones();

	for (int iter = 0; iter < NUM_ITERATIONS; ++iter) {
		for (int ant = 0; ant < NUM_ANTS; ++ant) {
			visited.assign(NUM_CITIES, false);
			int startCity = rand() % NUM_CITIES;
			visited[startCity] = true;
			antsPaths[ant][0] = startCity;

			for (int i = 1; i < NUM_CITIES; ++i) {
				int nextCity = selectNextCity(ant, visited);
				visited[nextCity] = true;
				antsPaths[ant][i] = nextCity;
			}
		}

		calculateProbabilities();
		updatePheromones(antsPaths);
	}
}

int main() {
	srand(static_cast<unsigned int>(time(nullptr)));
	solveTSP();

	std::cout << "Финальные феромоны на рёбрах:\n";
	for (int i = 0; i < NUM_CITIES; ++i) {
		for (int j = 0; j < NUM_CITIES; ++j) {
			std::cout << pheromones[i][j] << " ";
		}
		std::cout << std::endl;
	}

	return 0;
}
